using CarRentalMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers
{
    public class UserListController : Controller
    {
        private readonly IUserService _userService;

        public UserListController(IUserService userService)
        {
            _userService = userService;
        }
        [Route("UserList")]
        public async Task<IActionResult> UserList()
        {
            var users = await _userService.GetUsersAsync();
            return View("~/Views/User/UserList.cshtml", users);
        }
    }
}
