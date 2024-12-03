using CarRentalMVC.Services;
using CarRentalService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers.User
{
    public class UserEditController : Controller
    {
        private readonly IUserService _userService;
        public UserEditController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("UserEdit/{id?}")]
        public async Task<IActionResult> UserEdit(int id)
        {
            UserDto user = id > 0 ? await _userService.GetUserAsync(id) : new UserDto();

            return View("~/Views/User/UserEdit.cshtml", user);
        }

        [HttpPost]
        [Route("UserUpdate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserUpdate(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateUserAsync(userDto);

                if (result.IsSuccessful)
                {
                    return RedirectToAction("UserList", "UserList");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı güncellenirken bir hata oluştu.");
                }
            }

            return View("~/Views/User/UserEdit.cshtml", userDto);
        }
    }
}

