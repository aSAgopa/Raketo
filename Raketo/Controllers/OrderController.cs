using Microsoft.AspNetCore.Mvc;
using Raketo.Interfaces;
using Raketo.Model.Enums;
using Raketo.ViewModel;


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
        public async Task<IActionResult> IndexAsync(Guid userId, string name, int amount, decimal price, Products category,Guid productid,
            decimal quantity, Guid productId)
        {
            await _productsService.UpdateProductQuantityAsync(productid,amount);
           
            var order = new OrderViewModel
            {
                Id = Guid.NewGuid(),
                ProductName = name,
                Amount = amount,
                UserId = userId,
                Price = price,
                ProductId = productid
            };
           await _orderService.AddAsync(order);
           return RedirectToAction("ProductsIndex", "Products", new { userId, category });
        }

        public async Task<IActionResult> OrdersCartAsync(Guid userId)
        {
            var result = await _orderService.GetAllAsync(userId);
            ViewBag.UserId = userId;
            return View(result);
        }
        public async Task<IActionResult> OrderDeleteAsync(Guid Id, Guid userId) 
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
        public async Task<IActionResult> ProcessPaymentAsync(Guid userId, string totalPrice, string name,
            string surname, string numberCard, string cvv) 
        {
           var result = await _orderService.SendCustomerBankInfoAsync(userId,totalPrice,name,surname, numberCard, cvv);
           if(result == true) 
           {
           await _orderService.DeleteAllOrdersAsync(userId);
           ViewBag.TotalPrice = Convert.ToDecimal(totalPrice);
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
