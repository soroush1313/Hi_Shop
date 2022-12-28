﻿using Hi_Shop.Domain.Attributes;
using Hi_Shop.Domain.Discounts;

namespace Hi_Shop.Domain.Catalogs
{
    [Auditable]
    public class CatalogItem
    {
        private int _price = 0;
        private int? _oldPrice = null;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? OldPrice
        {
            get
            {
                return _oldPrice;
            }
            set
            {
                OldPrice = _oldPrice;
            }
        }

        public int Price
        {
            get
            {
                return GetPrice();
            }
            set
            {
                Price = _price;
            }
        }

        public int? PercentDiscount { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        //tedad mojude
        public int AvailableStock { get; set; }
        //mojudie mahsul be kmtr az in meqdar resid sharzh konim
        public int RestockThreshold { get; set; }
        //saghfe sefaresh
        public int MaxStockThreshold { get; set; }
        public int VisitCount { get; set; }

        public ICollection<CatalogItemFeature> CatalogItemFeatures { get; set; }
        public ICollection<CatalogItemImage> CatalogItemImages { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<CatalogItemFavourite> CatalogItemFavourites { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }


        private int GetPrice()
        {
            var dis = GetPreferredDiscount(Discounts, _price);
            if (dis != null)
            {
                var discountAmount = dis.GetDiscountAmount(_price);
                int newPrice = _price - discountAmount;
                _oldPrice = _price;
                PercentDiscount = (discountAmount * 100) / _price;
                return newPrice;
            }

            return _price;
        }

        private Discount GetPreferredDiscount(ICollection<Discount> discounts , int price)
        {
            Discount preferredDiscount = null;
            decimal? maximumDiscountValue = null;
            if (discounts != null)
            {
                foreach (var discount in discounts)
                {
                    var currentDiscountValue = discount.GetDiscountAmount(price);
                    if (currentDiscountValue != decimal.Zero)
                    {
                        if (!maximumDiscountValue.HasValue || currentDiscountValue > maximumDiscountValue)
                        {
                            maximumDiscountValue = currentDiscountValue;
                            preferredDiscount = discount;
                        }
                    }
                }
            }

            return preferredDiscount;
        }
    }
}
