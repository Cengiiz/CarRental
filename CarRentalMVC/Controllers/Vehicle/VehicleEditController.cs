using CarRentalMVC.Services;
using CarRentalService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers
{
    public class VehicleEditController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public VehicleEditController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [Route("VehicleEdit/{id?}")]
        public async Task<IActionResult> VehicleEdit(int id)
        {
            VehicleDto vehicle = id > 0 ? await _vehicleService.GetVehicleAsync(id) : new VehicleDto();

            return View("~/Views/Vehicle/VehicleEdit.cshtml", vehicle);
        }

        [HttpPost]
        [Route("VehicleUpdate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VehicleUpdate(VehicleDto vehicleDto)
        {
            if (ModelState.IsValid)
            {

                var result = await _vehicleService.UpdateVehicleAsync(vehicleDto);

                if (result.IsSuccessful)
                {
                    return RedirectToAction("VehicleList", "VehicleList");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı güncellenirken bir hata oluştu.");
                }
            }

            return View("~/Views/Vehicle/VehicleEdit.cshtml", vehicleDto);
        }
    }
}

