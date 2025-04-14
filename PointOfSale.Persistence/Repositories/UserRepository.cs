using Microsoft.EntityFrameworkCore;
using PointOfSale.Domain.Entities;
using PointOfSale.Application.Interfaces;
using PointOfSale.Persistence.Data;

namespace PointOfSale.Persistence.Repositories
{
    class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        public async Task<User> AddUser(User user)
        {
            var addedUser = appDbContext.Users.Add(user);
            await appDbContext.SaveChangesAsync();
            return addedUser.Entity;
        }

        public Task<User> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Order>> GetAllOrdersOfAUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            var users = await appDbContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return user;
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}
