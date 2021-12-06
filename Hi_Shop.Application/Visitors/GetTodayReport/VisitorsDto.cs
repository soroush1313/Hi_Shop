using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Shop.Application.Visitors.GetTodayReport
{
    public class VisitorsDto
    {
        public string Id { get; set; }
        public string Ip { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Browser { get; set; }
        public string OperationSystem { get; set; }
        public bool IsSpider { get; set; }
        public DateTime Time { get; set; }
        public string VisitorId { get; set; }
    }
}
