
namespace Raketo.Interfaces
{
    public interface IOrderService<T> where T : class
    {
       Task<T> GetByIdAsync(Guid id);
       Task<IEnumerable<T>> GetAllAsync(Guid userId);
       Task AddAsync(T order);
       Task DeleteAsync(Guid id);
       Task DeleteAllOrdersAsync(Guid userId);
       Task<bool> SendCustomerBankInfoAsync(Guid userId, string totalPrice, string name,string surname, string numberCard, string cvv);

    }
    
}
