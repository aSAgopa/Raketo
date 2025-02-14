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
        public async Task<IActionResult> ProductsIndex(Products category, Guid userId)
        {
            var result = await _productService.GetAllAsync(category);
            ViewBag.UserId = userId;
            return View(result);
        }
        public async Task<IActionResult> ProductsOverview(Products category)
        {
            var result = await _productService.GetAllAsync(category);
            return View(result);
        }




    }
}
