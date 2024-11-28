﻿using Microsoft.AspNetCore.Mvc;
using Raketo.Managers;

namespace Raketo.Controllers
{
    public class ClientController : Controller
    {
        Repository Repository { get; set; }
        public ClientController(Repository rep)
        {
            Repository = rep;
        }
        public async Task<IActionResult> ClientIndex(int id)
        {
            var result = Repository.GetProductsAsync(id);
            return View(await result);
        }
        public async Task<IActionResult> BuyOrder(int categoriesId,int id, int count,string name, double Price)
        {
           await Repository.BuildingOrders(count,name, Price);
           await Repository.ChangeQuantity(categoriesId,id,count);
           return RedirectToAction("ClientIndex", new { id = categoriesId });
               
        }
        //public async Task<IActionResult> ShoppingCart()
        //{
        
        //}
    }
}
