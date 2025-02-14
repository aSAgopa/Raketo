using Raketo.DAL.Entities;
using Raketo.Model.Enums;
using Raketo.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Raketo.DAL
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly MarketDBContext _dbContext;
        public UserRepository(MarketDBContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> AddAsync(User user)
        {
            bool exists = await _dbContext.Users.AnyAsync(u => u.Name == user.Name || u.Email == user.Email);
            if (exists)
            {
                return false;
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }



        public async Task DeleteAsync(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
               _dbContext.Users.Remove(user);
               await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync(UserTypes user)
        {
           return await _dbContext.Users.ToListAsync();
        }
        

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<User?> GetByCredentialsAsync(string login, string password)
        {
            return await _dbContext.Users
                .Where(u => u.Name == login && u.Email == password)
                .FirstOrDefaultAsync();
        }


    }
}
