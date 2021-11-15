using Hi_Shop.Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace Hi_Shop.Domain.Users
{
    [Auditable]
    public class User:IdentityUser
    {
        public string FullName { get; set; }
    }
}
