using Microsoft.EntityFrameworkCore;
using Raketo.DAL.Entities;
using Raketo.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketo.DAL
{
    public class OrderRepository : IOrderRepository<Order>
    {
        private readonly MarketDBContext _dbContext;
        public OrderRepository(MarketDBContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync(Guid userId)
        {
            return await _dbContext.Orders.ToListAsync();
            
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
