using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers.Menu
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
