﻿using CarRentalMVC.Services;
using CarRentalService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("Login")]
        public IActionResult Login()
        {

            return View("~/Views/Login/Login.cshtml");
        }
        [Route("Validate")]
        [HttpPost]
        public async Task<IActionResult> LoginValidate(string username, string password)
        {
            var res = await _userService.ValidateUser(username, password);

            if (res != null && res.Id > 0 && res.IsActive)
            {
                SessionManager.SetUserSession(res);
                return RedirectToAction("Index","Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            SessionManager.ClearUserSession();
            return RedirectToAction("Login");
        }
    }
}
