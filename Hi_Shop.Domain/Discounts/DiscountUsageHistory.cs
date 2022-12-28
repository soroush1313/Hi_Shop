using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hi_Shop.Domain.Discounts
{
    public class DiscountUsageHistory
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public virtual Discount Discount { get; set; }
        public int DiscountId { get; set; }
        public Order.Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
