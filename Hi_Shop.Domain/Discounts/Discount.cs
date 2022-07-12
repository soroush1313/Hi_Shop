using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Domain.Attributes;
using Hi_Shop.Domain.Catalogs;

namespace Hi_Shop.Domain.Discounts
{
    [Auditable]
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool UsePercentage { get; set; }
        public int DiscountPercentage { get; set; }
        public int DiscountAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EnDate { get; set; }
        public bool ReqiresCouponCode { get; set; }
        public string CouponCode { get; set; }

        [NotMapped]
        public DiscountType DiscountType
        {
            get => (DiscountType)this.DiscountTypeId;
            set =>this.DiscountTypeId = (int)value;
        }

        public int DiscountTypeId { get; set; }
        public ICollection<CatalogItem> CatalogItems { get; set; }


        public int LimitationTimes { get; set; }

        [NotMapped]
        public DiscountLimitationType DiscountLimitation
        {
            get => (DiscountLimitationType)this.DiscountLimitationId;
            set => this.DiscountLimitationId = (int)value;
        }
        public int DiscountLimitationId { get; set; }

    }

    public enum DiscountType
    {
        AssignedProduct = 1,
        AssignedToCategories = 2,
        AssignedToUser = 3,
        AssignedToBrand = 4,
    }

    public enum DiscountLimitationType
    {
        Unlimited = 0,
        NTimesOnly = 1,
        NTimesPerCustomer = 2
    }
}
