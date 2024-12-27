using Raketo.DAL.Entities;
using Raketo.Model;
using Raketo.Model.Enums;

namespace Raketo.BL.Interfaces
{
    public interface IService<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(Products category);
        void Add(T data);
        void Delete(Guid id);
        void Update(ProductDto product);
       
    }
}