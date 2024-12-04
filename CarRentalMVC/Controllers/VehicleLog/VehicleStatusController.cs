using CarRentalCore.Models;
using CarRentalMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers.VehicleLog
{
    public class VehicleStatusController : Controller
    {
        private readonly IVehicleLogService _vehicleLogService;
        private readonly IVehicleService _vehicleService;
        public VehicleStatusController(IVehicleLogService vehicleLogService, IVehicleService vehicleService)
        {
            _vehicleLogService = vehicleLogService;
            _vehicleService = vehicleService;

        }
        [Route("VehicleStatus")]
        public IActionResult VehicleStatus()
        {
            return View("~/Views/VehicleLog/VehicleStatus.cshtml");
        }

        public async Task<IActionResult> GetAllVehicleStatus()
        {
            var vehicles = await _vehicleService.GetVehiclesAsync();  // VehicleLogs tablosu
            var vehicleLogs = await _vehicleLogService.GetVehicleLogsAsync();  // VehicleLogs tablosu
            var totalDuration = 168; // 7 gün * 24 saat

            var vehicleData = vehicleLogs.Select(vehicleLog => new
            {
                VehicleName = vehicles.FirstOrDefault(x => x.Id == vehicleLog.VehicleId)?.Name,
                WorkPercentage = (vehicleLog.ActiveWorkingHours / (float)totalDuration) * 100,
                MaintenancePercentage = (vehicleLog.MaintenanceHours / (float)totalDuration) * 100,
                IdlePercentage = (vehicleLog.IdleHours / (float)totalDuration) * 100
            }).ToList();

            return Json(vehicleData);
        }

    }
}
