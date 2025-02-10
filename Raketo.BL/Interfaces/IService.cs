using Raketo.DAL.Entities;
using Raketo.Model;
using Raketo.Model.Enums;

namespace Raketo.BL.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(Products category);
        Task AddAsync(T data);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(ProductDto product);
        Task UpdateProductQuantityAsync(Guid productId, int amount);
    }
}