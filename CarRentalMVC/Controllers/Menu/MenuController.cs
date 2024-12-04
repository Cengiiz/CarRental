//using CarRentalMVC.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace CarRentalMVC.Controllers.Menu
//{
//    public class MenuController : Controller
//    {
//        private readonly IMenuService _menuService;

//        public MenuController(IMenuService menuService)
//        {
//            _menuService = menuService;
//        }

//        public async Task<IActionResult> GetMenuItems()
//        {
//            var menuItems = await _menuService.GetMenuItemsAsync();
//            return PartialView("~/Views/Shared/_Menu.cshtml", menuItems);
//        }
//    }
//}
