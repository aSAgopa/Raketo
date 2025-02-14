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
        public IActionResult FormAuthorization()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FormAuthorization(string login, string password)
        {
            var user = await _userService.GetByCredentialsAsync(login, password);

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
        public async Task<IActionResult> Registration(string login, string password)
        {
              if (login == Admin.login && password == Admin.password || !await _userService.RegisterUserAsync(login, password))
                {
                    ViewBag.Error = "User with the same Name or Email already exists.";
                    return View();
                }

                return RedirectToAction("FormAuthorization");
                    
        }
    }



}
