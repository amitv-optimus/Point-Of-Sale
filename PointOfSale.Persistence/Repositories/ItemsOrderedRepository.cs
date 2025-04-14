using Microsoft.EntityFrameworkCore;
using PointOfSale.Application.Interfaces;
using PointOfSale.Domain.Entities;
using PointOfSale.Persistence.Data;

namespace PointOfSale.Persistence.Repositories
{
    public class ItemsOrderedRepository(AppDbContext appDbContext) : IItemsOrderedRepository
    {
        public async Task<Guid> AddItemOrdered(ItemsOrdered itemsOrdered)
        {
            var createdItemsOrdered = appDbContext.ItemsOrdered.Add(itemsOrdered);
            await appDbContext.SaveChangesAsync();
            return createdItemsOrdered.Entity.Id;
        }

        public async Task<bool> DeleteItemOrdered(Guid id)
        {
            var itemsOrdered = await appDbContext.ItemsOrdered.FirstOrDefaultAsync(x => x.Id == id);
            if (itemsOrdered == null)
            {
                throw new Exception("ItemsOrdered not found");
            }
            var deletedItemsOrdered = appDbContext.ItemsOrdered.Remove(itemsOrdered);
            await appDbContext.SaveChangesAsync();
            return deletedItemsOrdered.State == EntityState.Deleted;
        }
    }
}
