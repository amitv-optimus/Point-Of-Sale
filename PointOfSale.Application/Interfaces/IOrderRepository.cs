using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Guid> CreateOrder(Order order);
        public Task<Order> GetOrderById(Guid id);
        public Task<ICollection<Order>> GetAllOrders();
        public Task<ICollection<Order>> GetOrdersByUserId(Guid userId);
        public Task<Guid> UpdateOrder(Order order);
        public Task<bool> DeleteOrder(Guid id);
        public Task<Guid> UpdateOrderStage(Guid id, string stage);
    }
}
