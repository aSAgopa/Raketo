using Microsoft.AspNetCore.Mvc;

namespace Raketo.Controllers
{
    public class UserController : Controller
    {

        public IActionResult User(Guid id)
        {            
           return View(id);
        }
        public IActionResult Admin()
        {
            return View();
        }
    }
}
