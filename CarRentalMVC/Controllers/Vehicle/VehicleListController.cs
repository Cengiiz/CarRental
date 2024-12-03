using CarRentalMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers
{
    public class VehicleListController : Controller
    {
        private readonly IVehicleService _vehicleService;

        public VehicleListController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [Route("VehicleList")]
        public async Task<IActionResult> VehicleList()
        {
            var vehicles = await _vehicleService.GetVehiclesAsync();
            return View("~/Views/Vehicle/VehicleList.cshtml", vehicles);
        }
    }
}
