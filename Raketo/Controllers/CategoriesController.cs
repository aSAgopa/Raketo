using Microsoft.AspNetCore.Mvc;
using Raketo.Interfaces;
using Raketo.Model.Enums;
using Raketo.ViewModel;

namespace Raketo.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUiService<ProductViewModel> _productService;
        public CategoriesController(IUiService<ProductViewModel> productViewModel)
        {
            _productService = productViewModel;
        }

        [HttpGet]
        public IActionResult Index(Products category)
        {
            var result = _productService.GetAll().Where(p => p.Category == category).ToList();
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
            //public IActionResult Edit(int id, int idFor)
            //{
            //    var result = Rep.CreateModel(id, idFor);
            //    return View(result);
            //}
            //[HttpPost]
            //public async Task<IActionResult> Edit(ProductViewModel model)
            //{
            //    await Rep.UpdateProductAsync(model);
            //    return RedirectToAction("Index", new { id = model.CategoresID });
            //}

        }
}
