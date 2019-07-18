using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Login.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Login.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!string.IsNullOrEmpty(user.UserName) && string.IsNullOrEmpty(user.Password))
            {
                return RedirectToAction("login");
            }
            User _user = _userRepository.GetUserByUserName(user.UserName, user.Password);
            if (_user != null)
            {
                if (user.Password != _user.Password)
                {
                    return RedirectToAction("login"); // düzelt wrong password
                }
                if (_user.IsAdmin)
                {
                    return RedirectToAction("admin", new { id = _user.Id });
                }
                return RedirectToAction("user", new { id = _user.Id });
            }
            return View();
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}