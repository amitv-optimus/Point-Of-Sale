namespace PointOfSale.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<ItemsOrdered>? ItemsOrdered { get; set; }
    }
}
