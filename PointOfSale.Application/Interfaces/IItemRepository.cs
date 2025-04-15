using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Interfaces
{
    public interface IItemRepository
    {
        Task<ICollection<Item>> GetAllItems();
        Task<Item> GetItemById(Guid id);
        Task<Item> AddItem(Item item);
        Task<ICollection<Item>> AddItems(ICollection<Item> items);
        Task<Guid> UpdateItem(Item item);
        Task<Guid> DeleteItem(Guid id);
        Task<ICollection<ItemsOrdered>> GetItemsOrderedInfo(Guid id);
    }
}
