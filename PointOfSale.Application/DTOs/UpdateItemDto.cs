namespace PointOfSale.Application.DTOs
{
    public class UpdateItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
    }
}
