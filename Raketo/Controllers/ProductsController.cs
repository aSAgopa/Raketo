using Microsoft.AspNetCore.Mvc;
using Raketo.Interfaces;
using Raketo.Model.Enums;
using Raketo.ViewModel;

namespace Raketo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsServiceUI<ProductViewModel,Products> _productService;

        public ProductsController(IProductsServiceUI<ProductViewModel,Products> productViewModel)
        {
            _productService = productViewModel;
        }

        [HttpGet]
        public IActionResult ProductsIndex(Products category)
        {
            var result = _productService.GetAll(category).ToList();
            return View(result);
        }
        public IActionResult ProductsOverview(Products category)
        {
            var result = _productService.GetAll(category).ToList();
            return View(result);
        }




    }
}
