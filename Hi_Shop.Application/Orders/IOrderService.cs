﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hi_Shop.Application.Catalogs.CatalogItems.UriComposer;
using Hi_Shop.Application.Discounts;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Order;
using Microsoft.EntityFrameworkCore;

namespace Hi_Shop.Application.Orders
{
    public interface IOrderService
    {
        int CreateOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod);
    }

    public class OrderService : IOrderService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;
        private readonly IUriComposerService composerService;
        private readonly IDiscountHistoryService discountHistoryService;

        public OrderService(IDataBaseContext context, IMapper mapper, IUriComposerService composerService, IDiscountHistoryService discountHistoryService)
        {
            this.context = context;
            this.mapper = mapper;
            this.composerService = composerService;
            this.discountHistoryService = discountHistoryService;
        }
        public int CreateOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod)
        {
            var basket = context.Baskets.Include(p => p.Items)
                .Include(p=>p.AppliedDiscount)
                .SingleOrDefault(p => p.Id == BasketId);
            int[] Ids = basket.Items.Select(p => p.CatalogItemId).ToArray();
            var catalogItems = context.CatalogItems.Include(p => p.CatalogItemImages).Where(p => Ids.Contains(p.Id));
            var orderItems = basket.Items.Select(basketItem =>
            {
                var catalogItem = catalogItems.First(c => c.Id == basketItem.CatalogItemId);
                var orderItem = new OrderItem(catalogItem.Id,
                    catalogItem.Name,
                    composerService.ComposeImageUri(catalogItem.CatalogItemImages?.FirstOrDefault()?.Src ?? ""),
                    catalogItem.Price, basketItem.Quantity);
                return orderItem;
            }).ToList();

            var userAddress = context.UserAddresses.SingleOrDefault(p => p.Id == UserAddressId);
            var address = mapper.Map<Address>(userAddress);
            var order = new Order(basket.BuyerId, address, orderItems, paymentMethod, basket.AppliedDiscount);
            context.Orders.Add(order);
            context.Baskets.Remove(basket);
            context.SaveChanges();
            if (basket.AppliedDiscount != null)
            {
                discountHistoryService.InsertDiscountUsageHistory(basket.Id , order.Id);
            }
            return order.Id;
        }
    }
}
