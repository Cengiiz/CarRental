using CarRentalMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;

        public MenuViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var menuItems = await _menuService.GetMenuItemsAsync();
            var user = SessionManager.GetUserSession();
            var menuItems = await _menuService.GetUserMenuItemsAsync(user?.Id > 0 ? user.Id : 0);
            return View("~/Views/Shared/_Menu.cshtml", menuItems);
        }
    }

}
