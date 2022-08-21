using CarVenture.Core.Interfaces;
using CarVenture.Dtos;
using CarVenture.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarVenture.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRequestDto userRequestDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.AddAsync(userRequestDto);
                }
                catch (Exception)
                {
                    return View(userRequestDto);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(userRequestDto);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if(!_authService.Login(loginModel.Email, loginModel.Password))
                {
                    ModelState.AddModelError("", "These credentials do not match our records");
                    return View(loginModel);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(loginModel);
        }
    }
}
