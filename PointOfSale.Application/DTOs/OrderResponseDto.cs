using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.DTOs
{
    public class OrderResponseDto
    {
        public string Stage { get; set; } = null!;
        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public ICollection<ItemOrderResponseDto> ItemsOrdered { get; set; } = null!;
    }
}
