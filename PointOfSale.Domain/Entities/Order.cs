using PointOfSale.Domain.Constants;

namespace PointOfSale.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Stage { get; set; } = null!;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime Created { get; set; }
        public ICollection<ItemsOrdered> ItemsOrdered { get; set; } = null!;
    }
}
