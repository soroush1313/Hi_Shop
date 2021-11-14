using Hi_Shop.Domain.Attributes;

namespace Hi_Shop.Domain.Users
{
    [Auditable]
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
    }
}
