using Microsoft.AspNetCore.Mvc;
using Raketo.ViewModel;
using Raketo.Models;
using Raketo.Model.Enums;
using Raketo.Interfaces;

namespace Raketo.Controllers
{
    public class AuthorizationController : Controller
    {
        IUsersServiceUI<UserViewModel, UserTypes> _userService;
        public AuthorizationController(IUsersServiceUI<UserViewModel, UserTypes> uiService)
        {
            _userService = uiService;
        }
        [HttpGet]
        public IActionResult FormAutorization()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FormAutorizationAsync(string login, string password)
        {
            var users = await _userService.GetAllAsync(UserTypes.User);
            var user = users.FirstOrDefault(p => p.Name == login && p.Email == password);
            
            if (login == Admin.login && password == Admin.password)
            {
                
                return RedirectToAction("Admin", "User");
            }

            else if (user != null)
            {
                return RedirectToAction("User", "User", new { id = user.Id });
            }
            else
            {
                
                ViewBag.Error = "Invalid login or password.";
                return View(); 
            }

        }
        [HttpGet]
        public IActionResult Registration() => View();

        [HttpPost]
        public async Task<IActionResult> RegistrationAsync(string login, string password)
        {
            var user = new UserViewModel() { Name = login, Email = password, Id = Guid.NewGuid() };
            if (login == Admin.login && password == Admin.password)
            {
                ViewBag.Error = "User with the same Name or Email already exists.";
                return View();
            }
            else
            {
                var result = await _userService.AddAsync(user);

                if (result)
                {
                   return RedirectToAction ("FormAutorization");
                }

                else
                {
                    ViewBag.Error = "User with the same Name or Email already exists.";
                    return View();
                }
            }
            

        }
    }



}
