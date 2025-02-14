using Microsoft.AspNetCore.Mvc;
using Raketo.Interfaces;
using Raketo.Model.Enums;
using Raketo.ViewModel;
using Raketo.Models;



namespace Raketo.Controllers
{
    public class OrderController : Controller
    {
       private readonly IOrderService<OrderViewModel> _orderService;
       private readonly IProductsServiceUI<ProductViewModel, Products> _productsService;
       
       
        public OrderController(IOrderService<OrderViewModel> orderService, IProductsServiceUI<ProductViewModel,
            Products> productsService)
        {
            _orderService = orderService;
            _productsService = productsService;
           
        }
        public async Task<IActionResult> Index(OrderViewModel оrderViewModel,Products category)
        {
            await _productsService.UpdateProductQuantityAsync(оrderViewModel.ProductId, оrderViewModel.Amount);
            await _orderService.AddAsync(оrderViewModel);
           return RedirectToAction("ProductsIndex", "Products", new { оrderViewModel.UserId, category });
        }

        public async Task<IActionResult> OrdersCart(Guid userId)
        {
            var result = await _orderService.GetAllAsync(userId);
            ViewBag.UserId = userId;
            return View(result);
        }
        public async Task<IActionResult> OrderDelete(Guid Id, Guid userId) 
        {
            await _orderService.DeleteAsync(Id);
            return RedirectToAction("OrdersCart", new { userId });
        }
        public IActionResult OrdersPayment(Guid userId,string totalPrice) 
        {
            ViewBag.TotalPrice = totalPrice;
            ViewBag.UserId = userId;
            return View();
        }
        public async Task<IActionResult> ProcessPayment(CustomerBankInfo customerBankInfo, Guid userId) 
        {
           var result = await _orderService.SendCustomerBankInfoAsync(customerBankInfo);
           if(result == true) 
           {
           await _orderService.DeleteAllOrdersAsync(userId);
           ViewBag.TotalPrice = Convert.ToDecimal(customerBankInfo.TotalPrice);
           ViewBag.UserId = userId;
           return View();
           }
           else
           {

                TempData["Error"] = "Invalid process of payment.";
                return RedirectToAction("OrdersPayment");
                
           }
        }

    }
}
