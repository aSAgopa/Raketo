using Raketo.Model.Enums;

namespace Raketo.DAL.Entities.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(Products category);
        void Add(T user);
        void Delete(Guid id);
        void Update(Product product);
    }
}