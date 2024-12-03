using CarRentalMVC.Services;
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

        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var res = await _userService.ValidateUser(userDto.UserName, userDto.PasswordHash);

            if (res.IsSuccessful)
            {
                SessionManager.SetUserSession(userDto);
                return RedirectToAction("Index", "Home");
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
