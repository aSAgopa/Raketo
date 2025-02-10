using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketo.BL.Interfaces
{
    public interface IOrderServiceBL<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task <IEnumerable<T>> GetAllAsync(Guid userId);
        Task AddAsync(T user);
        Task DeleteAsync(Guid id);
        Task DeleteAllOrdersAsync(Guid userId);
        Task<bool> SendCustomerBankInfoAsync(Guid userId, string totalPrice, string name,
            string surname, string numberCard, string cvv);
    }
}
