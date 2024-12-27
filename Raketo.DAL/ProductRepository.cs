using Raketo.DAL.Entities;
using Raketo.DAL.Entities.Interfaces;
using Raketo.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raketo.DAL
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly MarketDBContext _dbContext;
        public ProductRepository(MarketDBContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Product> GetAll(Products category)
        {

            return _dbContext.Products.Where(p => p.Category == category); 
          
        }

        public void Add(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }


        public Product GetById(Guid id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }
        public void Update(Product product)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Category = product.Category;
                existingProduct.Quantity = product.Quantity;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} was not found.");
            }
        }
    }

}
