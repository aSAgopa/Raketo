namespace Raketo.Interfaces
{
    public interface IUsersServiceUI<T, K> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll(K data);
        bool Add(T data);
        void Delete(Guid id);
        void Update(T data);
    }

}
