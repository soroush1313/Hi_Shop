using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Attributes;
using Hi_Shop.Domain.Banners;
using Hi_Shop.Domain.Baskets;
using Hi_Shop.Domain.Catalogs;
using Hi_Shop.Domain.Discounts;
using Hi_Shop.Domain.Order;
using Hi_Shop.Domain.Payments;
using Hi_Shop.Domain.Users;
using Hi_Shop.Persistence.EntityConfigurations;
using Hi_Shop.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Hi_Shop.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            //Database.EnsureCreated();

        }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountUsageHistory> DiscountUsageHistories { get; set; }
        public DbSet<CatalogItemFavourite> CatalogItemFavourites { get; set; }
        public DbSet<Banner> Banners { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    builder.Entity(entityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    builder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    builder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                    builder.Entity(entityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false);
                }
            }
            builder.Entity<CatalogType>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<BasketItem>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            builder.Entity<Basket>().HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);


            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());

            DataBaseContextSeed.CatalogSeed(builder);

            builder.Entity<Order>().OwnsOne(p => p.Address);

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Modified ||
                p.State == EntityState.Added ||
                p.State == EntityState.Deleted
                );
            foreach (var item in modified)
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                if (entityType != null)
                {
                    var inserted = entityType.FindProperty("InsertTime");
                    var updated = entityType.FindProperty("UpdateTime");
                    var RemoveTime = entityType.FindProperty("RemoveTime");
                    var IsRemoved = entityType.FindProperty("IsRemoved");

                    if (item.State == EntityState.Added && inserted != null)
                    {
                        item.Property("InsertTime").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Modified && updated != null)
                    {
                        item.Property("UpdateTime").CurrentValue = DateTime.Now;
                    }

                    if (item.State == EntityState.Deleted && RemoveTime != null && IsRemoved != null)
                    {
                        item.Property("RemoveTime").CurrentValue = DateTime.Now;
                        item.Property("IsRemoved").CurrentValue = true;
                        item.State = EntityState.Modified;
                    }
                }

            }

            return base.SaveChanges();
        }
    }
}
