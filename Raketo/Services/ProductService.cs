using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.DAL.Entities;
using Raketo.DAL;
using Raketo.Interfaces;
using Raketo.Model;
using Raketo.ViewModel;
using Raketo.BL.Services;

namespace Raketo.Services
{
    public class ProductService : IUiService<ProductViewModel>
    {
        private readonly IService<ProductDto> _productService;
        private readonly IMapper _mapper;

        public ProductService(IService<ProductDto> service, IMapper mapper)
        {
            _productService = service;
            _mapper = mapper;
        }

        public void Add(ProductViewModel data)
        {
            var product = _mapper.Map<ProductDto>(data);
            _productService.Add(product);
            
        }

        public void Delete(Guid id)
        {
            _productService.Delete(id);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _mapper.Map<List<ProductViewModel>>(_productService.GetAll());
        }

        public ProductViewModel GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(_productService.GetById(id));
        }
        public void Update(ProductViewModel data)
        {
            var product = _mapper.Map<ProductDto>(data);
            _productService.Update(product);
        }
    }
}
