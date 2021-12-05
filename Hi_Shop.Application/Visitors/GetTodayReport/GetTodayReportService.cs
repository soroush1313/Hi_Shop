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

            var todayPageViewCount=visitorMongoCollection.AsQueryable()
                .Where(p=>p.Time>=start && p.Time<end).LongCount();

            var todayVisitorCount=visitorMongoCollection.AsQueryable()
                .Where(p=>p.Time>=start && p.Time<end).GroupBy(p=>p.VisitorId).LongCount();

            var allPageViewCount=visitorMongoCollection.AsQueryable().LongCount();
            var allVisitorCount=visitorMongoCollection.AsQueryable().GroupBy(p=>p.VisitorId).LongCount();

            return new ResultTodayReportDto
            {
                GeneralState = new GeneralStateDto
                {
                    TotalVisitors = allVisitorCount,
                    TotalPageViews = allPageViewCount,
                    PageViewsPerVisit = allVisitorCount / allVisitorCount
                },
                Today = new TodayDto
                {
                    PageViews = todayPageViewCount,
                    Visitors = todayVisitorCount,
                    ViewsPerVisitor = todayPageViewCount / todayVisitorCount
                }
            };
        }
    }
}
