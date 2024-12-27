using Microsoft.AspNetCore.Mvc;
using Raketo.Interfaces;
using Raketo.Model.Enums;
using Raketo.ViewModel;

namespace Raketo.Controllers
{
    public class UserController : Controller
    {
        private readonly IUiService<ProductViewModel> _productService;

        public UserController(IUiService<ProductViewModel> productViewModel)
        {
            _productService = productViewModel;
        }

        [HttpGet]
        public IActionResult UserIndex(Products category)
        {
            var result = _productService.GetAll(category).ToList();
            return View(result);
        }


        //public IActionResult BuyOrder(int categoriesId, int id, int count, string name, double Price)
        //{
        //    //await Repository.BuildingOrders(count, name, Price);
        //    //await Repository.ChangeQuantity(categoriesId, id, count);
        //    //return RedirectToAction("ClientIndex", new { id = categoriesId });

        //}

    }
}
