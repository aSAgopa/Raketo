using Microsoft.AspNetCore.Mvc;
using Raketo.Interfaces;
using Raketo.Models;

namespace Raketo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
        
    }
}
