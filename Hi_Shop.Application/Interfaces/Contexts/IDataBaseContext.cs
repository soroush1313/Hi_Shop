using System.Diagnostics.CodeAnalysis;
using Hi_Shop.Domain.Banners;
using Hi_Shop.Domain.Baskets;
using Hi_Shop.Domain.Catalogs;
using Hi_Shop.Domain.Discounts;
using Hi_Shop.Domain.Order;
using Hi_Shop.Domain.Payments;
using Hi_Shop.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Hi_Shop.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<CatalogBrand> CatalogBrands { get; set; }
        DbSet<CatalogType> CatalogTypes { get; set; }
        DbSet<CatalogItem> CatalogItems { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<BasketItem> BasketItems { get; set; }
        DbSet<UserAddress> UserAddresses { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }
        DbSet<CatalogItemFavourite> CatalogItemFavourites { get; set; }
        DbSet<Banner> Banners { get; set; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry Entry([NotNull] object entity);
    }
}
