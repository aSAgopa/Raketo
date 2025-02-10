using Microsoft.EntityFrameworkCore;
using Raketo.DAL.Entities;
using Raketo.DAL.Interfaces;
using Raketo.Model.Enums;

namespace Raketo.DAL
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly MarketDBContext _dbContext;
        public ProductRepository(MarketDBContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Product>> GetAllAsync(Products category)
        {

            return await _dbContext.Products.Where(p => p.Category == category).ToListAsync(); 
          
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
               _dbContext.Products.Remove(product);
               await _dbContext.SaveChangesAsync();
            }
        }


        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
                existingProduct.Quantity = product.Quantity;
              await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} was not found.");
            }
        }
    }

}
