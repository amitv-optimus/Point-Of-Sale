using PointOfSale.Domain.Constants;

namespace PointOfSale.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = UserRoles.Customer;
        public ICollection<Order>? Orders { get; set; }
    }
}
