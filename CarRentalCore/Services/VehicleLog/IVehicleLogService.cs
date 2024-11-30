using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public interface IVehicleLogService
    {
        Task<VehicleLog> GetByIdAsync(int id);
        Task<IEnumerable<VehicleLog>> GetAllAsync();
        Task<VehicleLog> CreateAsync(VehicleLog vehicleLog);
        Task<VehicleLog> UpdateAsync(VehicleLog vehicleLog);
        Task<bool> DeleteAsync(int id);
    }
}
