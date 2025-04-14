namespace PointOfSale.Application.DTOs
{
    public class OrderCreateDto
    {
        public List<ItemOrderDto> ItemsOrdered { get; set; } = null!;
    }
}
