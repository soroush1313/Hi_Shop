namespace Hi_Shop.Application.Visitors.GetTodayReport
{
    public class ResultTodayReportDto
    {
        public GeneralStateDto GeneralState { get; set; }
        public TodayDto Today  { get; set; }
        public List<VisitorsDto> Visitors { get; set; }
    }
}
