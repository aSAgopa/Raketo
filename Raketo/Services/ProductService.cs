﻿using AutoMapper;
using Raketo.BL.Interfaces;
using Raketo.Interfaces;
using Raketo.Model.Enums;
using Raketo.Model;
using Raketo.ViewModel;
using Raketo.BL.Services;


namespace Raketo.Services
{
    public class ProductService : IProductsServiceUI<ProductViewModel, Products>
    {
        private readonly IService<ProductDto> _productService;
        private readonly IMapper _mapper;

        public ProductService(IService<ProductDto> service, IMapper mapper)
        {
            _productService = service;
            _mapper = mapper;
        }
        public IEnumerable<ProductViewModel> GetAll(Products category)
        {
            return _mapper.Map<List<ProductViewModel>>(_productService.GetAll(category));
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
