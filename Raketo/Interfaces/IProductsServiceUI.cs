namespace Raketo.Interfaces
{
    public interface IProductsServiceUI<T,K> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(K data);
        void Add(T data);
        void Delete(Guid id);
        void Update(T data);
    }
}