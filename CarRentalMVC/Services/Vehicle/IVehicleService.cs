using CarRentalService.DTOs;
using RestSharp;

namespace CarRentalMVC.Services
{
    public interface IVehicleService
    {
        Task<VehicleDto> GetVehicleAsync(int id);
        Task<List<VehicleDto>> GetVehiclesAsync();
        Task<RestResponse> UpdateVehicleAsync(VehicleDto userDto); 
    }
}
