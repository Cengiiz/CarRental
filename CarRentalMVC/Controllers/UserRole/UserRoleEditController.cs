using CarRentalMVC.Services;
using CarRentalService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers
{
    public class UserRoleEditController : Controller
    {
        private readonly IUserRoleService _userService;
        public UserRoleEditController(IUserRoleService userService)
        {
            _userService = userService;
        }
        [Route("UserRoleEdit/{id?}")]
        public async Task<IActionResult> UserRoleEdit(int id)
        {
            UserRoleDto user = id > 0 ? await _userService.GetUserRoleAsync(id) : new UserRoleDto();

            return View("~/Views/UserRole/UserRoleEdit.cshtml", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UserRoleDto userRoleDto)
        {
            if (ModelState.IsValid)
            {
                // Model doğruysa, güncelleme işlemi yapılır
                var result = await _userService.UpdateUserRoleAsync(userRoleDto);

                if (result.Id > 0)
                {
                    return RedirectToAction("UserRoleList");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı güncellenirken bir hata oluştu.");
                }
            }

            return View("~/Views/UserRole/UserRoleEdit.cshtml", userRoleDto);
        }
    }
}

