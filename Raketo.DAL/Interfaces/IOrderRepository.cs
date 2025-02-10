using Raketo.Model.Enums;

namespace Raketo.DAL.Interfaces
{
    public interface IOrderRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(Guid userId);
        Task AddAsync(T user);
        Task DeleteAsync(Guid id);
    }
}