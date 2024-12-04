using CarRentalCore.Models;
using CarRentalMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalMVC.Controllers.VehicleLog
{
    public class VehicleLogListController : Controller
    {
        private readonly IVehicleLogService _vehicleLogService;
        private readonly IVehicleService _vehicleService;
        public VehicleLogListController(IVehicleLogService vehicleLogService, IVehicleService vehicleService)
        {
            _vehicleLogService = vehicleLogService;
            _vehicleService = vehicleService;
        }
        [Route("VehicleLogList")]
        public async Task<IActionResult> VehicleLogList()
        {
            var vehicles = await _vehicleService.GetVehiclesAsync();
            var vehicleLogs = await _vehicleLogService.GetVehicleLogsAsync();
            vehicleLogs.ForEach(vehicleLog =>
            {
                vehicleLog.Vehicle = vehicles.FirstOrDefault(x => x.Id == vehicleLog.VehicleId);
                vehicleLog.VehicleName = vehicles.FirstOrDefault(x => x.Id == vehicleLog.VehicleId)?.Name;
            });
            return View("~/Views/VehicleLog/VehicleLogList.cshtml", vehicleLogs);
        }
    }
}
