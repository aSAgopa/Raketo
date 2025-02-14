using Raketo.Model.Enums;

namespace Raketo.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(UserTypes user);
        Task<bool> AddAsync(T user);
        Task DeleteAsync(Guid id);
        Task<T?> GetByCredentialsAsync(string login, string password);
    }

}