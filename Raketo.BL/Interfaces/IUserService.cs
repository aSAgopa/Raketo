using Raketo.Model.Enums;

namespace Raketo.BL.Interfaces
{
    public interface IUserService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(UserTypes user);
        Task<bool> AddAsync(T user);
        Task DeleteAsync(Guid id);
        Task<bool> RegisterUserAsync(string login, string password);
        Task<T> GetByCredentialsAsync(string login, string password);
    }
}