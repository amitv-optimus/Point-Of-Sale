using Microsoft.EntityFrameworkCore;
using PointOfSale.Domain.Entities;
using PointOfSale.Application.Interfaces;
using PointOfSale.Persistence.Data;

namespace PointOfSale.Persistence.Repositories
{
    public class ItemRepository(AppDbContext appDbContext) : IItemRepository
    {
        public async Task<Item> AddItem(Item item)
        {
            appDbContext.Add(item);
            await appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<Guid> DeleteItem(Guid id)
        {
            var item = await appDbContext.Items.FirstOrDefaultAsync(i => i.Id == id);
            if (item != null)
            {
                appDbContext.Items.Remove(item);
                await appDbContext.SaveChangesAsync();
            }
            return id;
        }

        public async Task<ICollection<Item>> GetAllItems()
        {
            var items = await appDbContext.Items.ToListAsync();
            return items;
        }

        public async Task<Item> GetItemById(Guid id)
        {
            var item = await appDbContext.Items.FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        public Task<ICollection<ItemsOrdered>> GetItemsOrderedInfo(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> UpdateItem(Item item)
        {
            appDbContext.Items.Update(item);
            appDbContext.SaveChanges();
            return Task.FromResult(item.Id);
        }
    }
}
