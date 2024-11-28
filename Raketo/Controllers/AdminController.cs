using Microsoft.AspNetCore.Mvc;

namespace Raketo.Controllers
{
    public class AdminController : Controller
    {
            
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
