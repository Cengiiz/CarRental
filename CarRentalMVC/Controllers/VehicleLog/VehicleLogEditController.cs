using CarRentalMVC.Services;
using CarRentalService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers
{
    public class VehicleLogEditController : Controller
    {
        private readonly IVehicleLogService _vehicleLogService;
        public VehicleLogEditController(IVehicleLogService vehicleService)
        {
            _vehicleLogService = vehicleService;
        }
        [Route("VehicleLogEdit/{id?}")]
        public async Task<IActionResult> VehicleLogEdit(int id)
        {
            VehicleLogDto vehicle = id > 0 ? await _vehicleLogService.GetVehicleLogAsync(id) : new VehicleLogDto();

            return View("~/Views/VehicleLog/VehicleLogEdit.cshtml", vehicle);
        }

        [HttpPost]
        [Route("VehicleLogUpdate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VehicleLogUpdate(VehicleLogDto vehicleLogDto)
        {
            if (ModelState.IsValid)
            {

                var result = await _vehicleLogService.UpdateVehicleLogAsync(vehicleLogDto);

                if (result.IsSuccessful)
                {
                    return RedirectToAction("VehicleLogList", "VehicleLogList");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı güncellenirken bir hata oluştu.");
                }
            }

            return View("~/Views/Vehicle/VehicleEdit.cshtml", vehicleLogDto);
        }
    }
}

