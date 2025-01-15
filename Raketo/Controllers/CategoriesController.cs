using Microsoft.AspNetCore.Mvc;
using Raketo.DAL.Entities;
using Raketo.Interfaces;
using Raketo.Model.Enums;
using Raketo.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public IActionResult Index(Products category)
        {
            var result = _productService.GetAll(category).ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new ProductViewModel());
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {

            _productService.Add(product);

            return RedirectToAction("Index", new { category = product.Category });
        }

        public IActionResult Delete(Guid Id, Products _category)
        {
            _productService.Delete(Id);
            return RedirectToAction("Index", new { category = _category });
        }
        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            var product = _productService.GetById(Id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            _productService.Update(product);
            return RedirectToAction("Index", new { category = product.Category } );
        }
        //private IRepository Rep { get; set; }

        //public CategoriesController(IRepository rp)
        //{
        //    Rep = rp;

        //}
        //public async Task<IActionResult> Index(int id)
        //{
        //    var result = Rep.GetProductsAsync(id);
        //    return View(await result);
        //}


        //}

    }
}
