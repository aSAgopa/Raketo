using Microsoft.AspNetCore.Mvc;
using Raketo.Interfaces;
using Raketo.Model.Enums;
using Raketo.ViewModel;

namespace Raketo.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IProductsServiceUI<ProductViewModel,Products> _productService;
        public CategoriesController(IProductsServiceUI<ProductViewModel,Products> productViewModel)
        {
            _productService = productViewModel;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(Products category)
        {
            var result = await _productService.GetAllAsync(category);
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductViewModel product)
        {

            await _productService.AddAsync(product);

            return RedirectToAction("Index", new { category = product.Category });
        }

        public async Task<IActionResult> DeleteAsync(Guid Id, Products _category)
        {
            await _productService.DeleteAsync(Id);
            return RedirectToAction("Index", new { category = _category });
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid Id)
        {
            var product = await _productService.GetByIdAsync(Id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(ProductViewModel product)
        {
            await _productService.UpdateAsync(product);
            return RedirectToAction("Index", new { category = product.Category } );
        }
       
    }
}
