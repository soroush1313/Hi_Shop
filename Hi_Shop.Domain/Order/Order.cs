﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Domain.Attributes;
using Hi_Shop.Domain.Catalogs;
using Hi_Shop.Domain.Discounts;

namespace Hi_Shop.Domain.Order
{
    [Auditable]
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; private set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public Address Address { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus PaymentStatus { get; private set; }
        public OrderStatus OrderStatus { get; set; }
        private readonly List<OrderItem> _orderItems = new List<OrderItem>();
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();


        public decimal DiscountAmount { get; private set; }
        public Discount AppliedDiscount { get; private set; }
        public int? AppliedDiscountId { get; private set; }

        public Order(string userId, Address address, List<OrderItem> orderItems, PaymentMethod paymentMethod, Discount discount)
        {
            UserId = userId;
            Address = address;
            _orderItems = orderItems;
            PaymentMethod = paymentMethod;
            if (discount != null)
            {
                ApplyDiscountCode(discount);
            }
        }


        public Order()
        {

        }



        /// <summary>
        /// پرداخت انجام شد
        /// </summary>
        public void PaymentDone()
        {
            PaymentStatus = PaymentStatus.Paid;
        }


        /// <summary>
        /// کالا تحویل داده شد
        /// </summary>
        public void OrderDelivered()
        {
            OrderStatus = OrderStatus.Delivered;
        }

        /// <summary>
        /// ثبت مرجوعی کالا
        /// </summary>
        public void OrderReturned()
        {
            OrderStatus = OrderStatus.Returned;
        }


        /// <summary>
        /// لغو سفارش
        /// </summary>
        public void OrderCancelled()
        {
            OrderStatus = OrderStatus.Cancelled;
        }

        public int TotalPrice()
        {
            int totalPrice = _orderItems.Sum(p => p.UnitPrice * p.Units);
            if (AppliedDiscount != null)
            {
                totalPrice -= AppliedDiscount.GetDiscountAmount(totalPrice);
            }
            return totalPrice;
        }

        /// <summary>
        /// دریافت مبلغ کل بدونه در نظر گرفتن کد تخفیف
        /// </summary>
        /// <returns></returns>
        public int TotalPriceWithOutDiscount()
        {
            int totalPrice = _orderItems.Sum(p => p.UnitPrice * p.Units);
            return totalPrice;
        }

        public void ApplyDiscountCode(Discount discount)
        {
            this.AppliedDiscount = discount;
            this.AppliedDiscountId = discount.Id;
            this.DiscountAmount = discount.GetDiscountAmount(TotalPrice());
        }

    }

}
[Auditable]
public class OrderItem
{
    public int Id { get; set; }
    public CatalogItem CatalogItem { get; set; }
    public int CatalogItemId { get; private set; }
    public string ProductName { get; private set; }
    public string PictureUri { get; private set; }
    public int UnitPrice { get; private set; }
    public int Units { get; private set; }

    public OrderItem(int catalogItemId, string productName, string pictureUri, int unitPrice, int units)
    {
        CatalogItemId = catalogItemId;
        ProductName = productName;
        PictureUri = pictureUri;
        UnitPrice = unitPrice;
        Units = units;
    }

    public OrderItem()
    {

    }
}

public class Address
{
    public string State { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string ReciverName { get; private set; }

    public Address(string city, string state, string zipCode, string postalAddress)
    {
        this.City = city;
        State = state;
        ZipCode = zipCode;
        PostalAddress = postalAddress;
    }
}

public enum PaymentMethod
{
    OnlinePayment = 0,
    PaymentOnTheSpot = 1
}

public enum PaymentStatus
{
    WaitingForPayment = 0,
    Paid = 1
}

public enum OrderStatus
{
    Processing = 0,
    Delivered = 1,
    Returned = 2,
    Cancelled = 3
}

