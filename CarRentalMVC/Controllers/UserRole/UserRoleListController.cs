using CarRentalMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers
{
    public class UserRoleListController : Controller
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleListController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [Route("UserRoleList")]
        public async Task<IActionResult> UserRoleList()
        {
            var users = await _userRoleService.GetUserRolesAsync();
            return View("~/Views/UserRole/UserRoleList.cshtml", users);
        }
    }
}
