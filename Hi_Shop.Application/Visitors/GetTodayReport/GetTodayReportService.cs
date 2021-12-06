using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Visitors;
using MongoDB.Driver;

namespace Hi_Shop.Application.Visitors.GetTodayReport
{
    public class GetTodayReportService : IGetTodayReportService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbCOntext;
        private readonly IMongoCollection<Visitor> visitorMongoCollection;
        public GetTodayReportService(IMongoDbContext<Visitor> mongoDbCOntext)
        {
            _mongoDbCOntext = mongoDbCOntext;
            visitorMongoCollection = _mongoDbCOntext.GetCollection();
        }

        public ResultTodayReportDto Execute()
        {
            var start = DateTime.Now.Date;
            var end = DateTime.Now.AddDays(1);

            var todayPageViewCount = visitorMongoCollection.AsQueryable()
                .Where(p => p.Time >= start && p.Time < end).LongCount();

            var todayVisitorCount = visitorMongoCollection.AsQueryable()
                .Where(p => p.Time >= start && p.Time < end).GroupBy(p => p.VisitorId).LongCount();

            var allPageViewCount = visitorMongoCollection.AsQueryable().LongCount();
            var allVisitorCount = visitorMongoCollection.AsQueryable().GroupBy(p => p.VisitorId).LongCount();

            VisitCountDto visitPerHour = GetVisitPerHour(start, end);

            VisitCountDto visitPerDay = GetVisitPerDay();

            var visitors = visitorMongoCollection.AsQueryable()
                .OrderByDescending(p => p.Time)
                .Take(10).Select(p => new VisitorsDto
                {
                    Id= p.Id,
                    Browser=p.Browser.Family,
                    CurrentLink=p.CurrentLink,
                    Ip=p.Ip,
                    OperationSystem=p.OperationSystem.Family,
                    IsSpider=p.Device.IsSpider,
                    ReferrerLink=p.ReferrerLink,
                    Time=p.Time,
                    VisitorId=p.VisitorId
                }).ToList();

            return new ResultTodayReportDto
            {
                GeneralState = new GeneralStateDto
                {
                    TotalVisitors = allVisitorCount,
                    TotalPageViews = allPageViewCount,
                    PageViewsPerVisit = GetAvg(allVisitorCount, allVisitorCount),
                    VisitPerDay = visitPerDay,
                },

                Today = new TodayDto
                {
                    PageViews = todayPageViewCount,
                    Visitors = todayVisitorCount,
                    ViewsPerVisitor = GetAvg(todayPageViewCount, todayVisitorCount),
                    VisitPerhour = visitPerHour,
                },
                Visitors = visitors
            };
        }





        private VisitCountDto GetVisitPerHour(DateTime start, DateTime end)
        {
            var todayPageViewList = visitorMongoCollection.AsQueryable()
                .Where(p => p.Time >= start && p.Time < end)
                .Select(p => new { p.Time }).ToList();

            VisitCountDto visitPerHour = new VisitCountDto()
            {
                Display = new string[24],
                Value = new int[24],
            };

            for (int i = 0; i < 24; i++)
            {
                visitPerHour.Display[i] = $"h-{i}";
                visitPerHour.Value[i] = todayPageViewList.Where(p => p.Time.Hour == i).Count();
            }

            return visitPerHour;
        }





        private VisitCountDto GetVisitPerDay()
        {
            DateTime MonthStart = DateTime.Now.Date.AddDays(-30);
            DateTime MonthEnds = DateTime.Now.Date.AddDays(1);
            var month_PageViewList = visitorMongoCollection.AsQueryable()
                .Where(p => p.Time >= MonthStart && p.Time < MonthEnds)
                .Select(p => new { p.Time }).ToList();

            VisitCountDto visitPerDay = new VisitCountDto() { Display = new string[31], Value = new int[31] };
            for (int i = 0; i <= 30; i++)
            {
                var currentDay = DateTime.Now.AddDays(i * (-1));
                visitPerDay.Display[i] = i.ToString();
                visitPerDay.Value[i] = month_PageViewList.Where(p => p.Time.Date == currentDay.Date).Count();
            }

            return visitPerDay;
        }




        private float GetAvg(long visitPage, long visitor)
        {
            if (visitor == 0)
            {
                return 0;
            }
            else
            {
                return visitPage / visitor;
            }
        }
    }
}
