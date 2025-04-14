using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Interfaces
{
    public interface IItemsOrderedRepository
    {
        Task<Guid> AddItemOrdered(ItemsOrdered itemsOrdered);
        Task<bool> DeleteItemOrdered(Guid id);
    }
}
