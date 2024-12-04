using CarRentalService.DTOs;
using RestSharp;

namespace CarRentalMVC.Services
{
    public interface IVehicleLogService
    {
        Task<VehicleLogDto> GetVehicleLogAsync(int id);
        Task<List<VehicleLogDto>> GetVehicleLogsAsync();
        Task<RestResponse> UpdateVehicleLogAsync(VehicleLogDto vehicleLogDto);
    }
}
