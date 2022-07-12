using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hi_Shop.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Hi_Shop.Application.Interfaces.Contexts
{
    public interface IIdentityDataBaseContext
    {
        DbSet<User> Users { get; set; }
    }
}
