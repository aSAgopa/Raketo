using Raketo.DAL.Entities;
using Raketo.Model;

namespace Raketo.BL.Interfaces
{
    public interface IService<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T data);
        void Delete(Guid id);
        void Update(ProductDto product);
       
    }
}