using CarRentalService.DTOs;

namespace CarRentalMVC.Services
{
    public interface IVehicleService
    {
        Task<VehicleDto> GetVehicleAsync(int id);
        Task<List<VehicleDto>> GetVehiclesAsync();
        Task<VehicleDto> UpdateVehicleAsync(VehicleDto userDto); 
    }
}
