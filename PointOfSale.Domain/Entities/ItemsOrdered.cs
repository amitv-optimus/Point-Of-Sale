namespace PointOfSale.Domain.Entities
{
    public class ItemsOrdered
    {
        public Guid Id { get; set; }
        public Guid ItemID { get; set; }
        public Item? Item { get; set; }
        public Guid OrderID { get; set; }
        public Order? Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
