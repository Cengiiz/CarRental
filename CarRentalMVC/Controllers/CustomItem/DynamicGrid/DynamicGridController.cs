using CarRentalMVC.Models.DynamicGrid;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers.CustomItem.DynamicGrid
{
    public class DynamicGridController : Controller
    {
        public IActionResult RenderGrid(DynamicGridViewModel model)
        {
            return PartialView("~/Views/Shared/CustomItem/DynamicGrid.cshtm", model.Data);
        }
    }
}
