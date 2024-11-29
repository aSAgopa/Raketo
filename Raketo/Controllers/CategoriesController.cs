using Microsoft.AspNetCore.Mvc;
using Raketo.Managers;
using Raketo.Interfaces;
using Raketo.Models;
using Raketo.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Raketo.Controllers
{
    public class CategoriesController : Controller
    {
        private IRepository Rep { get; set; }

        public CategoriesController(IRepository rp)
        {
            Rep = rp;

        }
        public async Task<IActionResult> Index(int id)
        {
            var result = Rep.GetProductsAsync(id);
            return View(await result);
        }
        public IActionResult Add(int id)
        {

            return View(Rep.AddProduct(id));
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel product)
        {
            await Rep.AddCategoryAsync(product);

            return RedirectToAction("Index", new { id = product.CategoresID });


        }
        public async Task<IActionResult> Delete(int id, int idFor)
        {
            if (idFor == 1 || idFor == 2 || idFor == 3 || idFor == 4)

            await Rep.DeleteCategoryAsync(id, idFor);
            return RedirectToAction("Index", new { id = idFor });


        }
        public IActionResult Edit(int id, int idFor)
        {
            var result = Rep.CreateModel(id, idFor);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            await Rep.UpdateProductAsync(model);
            return RedirectToAction("Index", new { id = model.CategoresID });
        }

    }
}
