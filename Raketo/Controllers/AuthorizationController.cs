using Microsoft.AspNetCore.Mvc;
using Raketo.Models;

namespace Raketo.Controllers
{
    public class AuthorizationController : Controller
    {
        

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Login(string login, string password)
            {
                if (login == Admin.login && password == Admin.password)
                {
                    return View("Successful");

                }
                else
                {
                    ViewBag.Error = "Invalid login or password.";
                    return View();
                }
            
        }
    }
}
