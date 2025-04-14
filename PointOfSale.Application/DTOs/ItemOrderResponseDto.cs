using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.DTOs
{
    public class ItemOrderResponseDto
    {
        public Guid ItemID { get; set; }
        public Guid OrderID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
