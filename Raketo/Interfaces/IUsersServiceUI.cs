namespace Raketo.Interfaces
{
    public interface IUsersServiceUI<T, K> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(K data);
        Task DeleteAsync(Guid id);
        Task<bool> RegisterUserAsync(string login, string password);
        Task<T> GetByCredentialsAsync(string login, string password);
    }

}
