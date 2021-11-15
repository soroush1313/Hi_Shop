using Hi_Shop.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Hi_Shop.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
