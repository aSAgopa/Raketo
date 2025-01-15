using Raketo.DAL.Entities.Interfaces;
using Raketo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raketo.Model.Enums;

namespace Raketo.DAL
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly MarketDBContext _dbContext;
        public UserRepository(MarketDBContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Add(User user)
        {
            bool exists = _dbContext.Users.Any(u => u.Name == user.Name || u.Email == user.Email);

            if (exists)
            {
             return false;
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return true;
        }


        public void Delete(Guid id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll(UserTypes user)
        {
            return _dbContext.Users;
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(p => p.Id == id);
        }


    }
}
