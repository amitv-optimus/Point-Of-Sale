using PointOfSale.Domain.Entities;

namespace PointOfSale.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByUserName(string userName);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(Guid id);
        Task<ICollection<Order>> GetAllOrdersOfAUser(Guid id);
    }
}
