using Raketo.Model;

namespace Raketo.BL.Interfaces
{
    public interface IOrderServiceBL<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(Guid userId);
        Task AddAsync(T user);
        Task DeleteAsync(Guid id);
        Task DeleteAllOrdersAsync(Guid userId);
        Task<bool> SendInfoToBankAsync(CustomerBankInfoDto customerBankInfo);
    }   
}
