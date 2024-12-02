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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                // Model doğruysa, güncelleme işlemi yapılır
                var result = await _userService.UpdateUserAsync(userDto);

                if (result.Id > 0)
                {
                    return RedirectToAction("UserList");
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

