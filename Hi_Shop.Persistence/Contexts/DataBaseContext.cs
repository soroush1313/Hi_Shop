using Hi_Shop.Application.Interfaces.Contexts;
using Hi_Shop.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Hi_Shop.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
