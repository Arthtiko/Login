using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Login.Models;
using Login.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Login.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public ViewResult User(int Id)
        {
                UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel()
            {
                User = _userRepository.GetUser(Id),
                Title = "User Screen"
            };
            return View(userDetailsViewModel);
        }

        public ViewResult Admin(int Id)
        {
            var model = _userRepository.GetAllUsers() ;
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            User _user = _userRepository.Update(user);
            return RedirectToAction("user", new { id = _user.Id});
        }
        [HttpGet]
        public ViewResult Update(int Id)
        {
            UserDetailsViewModel userDetailsViewModel = new UserDetailsViewModel()
            {
                User = _userRepository.GetUser(Id),
                Title = "Update Screen"
            };
            return View(userDetailsViewModel);
        }

        public IActionResult Delete(int Id)
        {
            User _user = _userRepository.Delete(Id);
            return RedirectToAction("admin");
        }
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            User _user = new User()
            {
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                Password = user.Password,
                IsAdmin = false
            };
            User us = _userRepository.Add(_user);
            return RedirectToAction("login");
        }
    }
}
