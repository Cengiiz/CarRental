using CarRentalMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers
{
    public class UserRoleListController : Controller
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserRoleListController(IUserRoleService userRoleService, IUserService userService, IRoleService roleService)
        {
            _userRoleService = userRoleService;
            _userService = userService;
            _roleService = roleService;
        }
        [Route("UserRoleList")]
        public async Task<IActionResult> UserRoleList()
        {
            var users = await _userService.GetUsersAsync();
            var roles = await _roleService.GetRolesAsync();
            var userRoles = await _userRoleService.GetUserRolesAsync();

            userRoles.ForEach(userRole =>
            {
                userRole.RoleName = roles.FirstOrDefault(x => x.Id == userRole.RoleId)?.Name;
                userRole.UserName = users.FirstOrDefault(x => x.Id == userRole.UserId)?.FirstName + " " + users.FirstOrDefault(x => x.Id == userRole.UserId)?.LastName;
            });
            return View("~/Views/UserRole/UserRoleList.cshtml", userRoles);
        }
    }
}
