using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.DAL.Entities;
using Raketo.DAL.Interfaces;
using Raketo.Model;
using Raketo.Model.Enums;


namespace Raketo.BL.Services
{
    public class ProductService : IService<ProductDto>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync(Products category)
        {
            var products = await _productRepository.GetAllAsync(category);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task AddAsync(ProductDto data)
        {
            var product = _mapper.Map<Product>(data);
            await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }


        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateAsync(ProductDto data)
        {
            var product = _mapper.Map<Product>(data);
            await _productRepository.UpdateAsync(product);
        }

        public async Task UpdateProductQuantityAsync(Guid productId, int amount)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            product.Quantity -= amount;
            await _productRepository.UpdateAsync(product);

        }
    }
}
