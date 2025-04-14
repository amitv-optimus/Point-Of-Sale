using Microsoft.EntityFrameworkCore;
using PointOfSale.Application.Interfaces;
using PointOfSale.Domain.Entities;
using PointOfSale.Persistence.Data;

namespace PointOfSale.Persistence.Repositories
{
    public class OrderRepository(AppDbContext appDbContext) : IOrderRepository
    {
        public async Task<Guid> CreateOrder(Order order)
        {
            var createdOrder = appDbContext.Orders.Add(order);
            await appDbContext.SaveChangesAsync();
            return createdOrder.Entity.Id;
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            var order = await GetOrderById(id);
            if(order != null)
            {
                appDbContext.Orders.Remove(order);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ICollection<Order>> GetAllOrders()
        {
            var orders = await appDbContext.Orders.ToListAsync();
            return orders;
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            var order = await appDbContext.Orders.Include(o => o.ItemsOrdered)
                .ThenInclude(io => io.Item)
                .FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task<ICollection<Order>> GetOrdersByUserId(Guid userId)
        {
            var orders = await appDbContext.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.ItemsOrdered)
                .ThenInclude(io => io.Item)
                .ToListAsync();
            return orders;
        }

        public Task<Guid> UpdateOrder(Order order)
        {
            var updatedOrder = appDbContext.Orders.Update(order);
            appDbContext.SaveChanges();
            return Task.FromResult(updatedOrder.Entity.Id);
        }

        public async Task<Guid> UpdateOrderStage(Guid id, string stage)
        {
            var order = await GetOrderById(id);
            if (order != null)
            {
                order.Stage = stage;
                appDbContext.Orders.Update(order);
                await appDbContext.SaveChangesAsync();
                return order.Id;
            }
            else
            {
                throw new Exception("Order not found");
            }
        }
    }
}
