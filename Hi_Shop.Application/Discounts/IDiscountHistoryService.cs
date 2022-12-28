using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Application.Dtos;
using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Common;
using Hi_Shop.Domain.Discounts;

namespace Hi_Shop.Application.Discounts
{
    public interface IDiscountHistoryService
    {
        void InsertDiscountUsageHistory(int discountId, int orderId);

        DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId);

        PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId,
            string? userId, int pageIndex, int pageSize);
    }

    public class DiscountHistoryService : IDiscountHistoryService
    {
        private readonly IDataBaseContext context;

        public DiscountHistoryService(IDataBaseContext context)
        {
            this.context = context;
        }
        public PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId, string? userId, int pageIndex, int pageSize)
        {
            var query = context.DiscountUsageHistories.AsQueryable();
            if (discountId.HasValue && discountId.Value > 0)
                query = query.Where(p => p.DiscountId == discountId.Value);
            if (!string.IsNullOrEmpty(userId))
                query = query.Where(p => p.Order != null && p.Order.UserId == userId);
            query = query.OrderByDescending(c => c.CreateOn);
            var pagedItems = query.PagedResult(pageIndex, pageSize, out int rowCount);
            return new PaginatedItemsDto<DiscountUsageHistory>(pageIndex, pageSize, rowCount, query.ToList());
        }

        public DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            if (discountUsageHistoryId == 0)
                return null;
            var discountUsage = context.DiscountUsageHistories.Find(discountUsageHistoryId);
            return discountUsage;
        }

        public void InsertDiscountUsageHistory(int discountId, int orderId)
        {
            var order = context.Orders.Find(orderId);
            var discount = context.Discounts.Find(discountId);
            DiscountUsageHistory discountUsageHistory = new DiscountUsageHistory()
            {
                CreateOn = DateTime.Now,
                Discount = discount,
                Order = order
            };
            context.DiscountUsageHistories.Add(discountUsageHistory);
            context.SaveChanges();
        }
    }
}
