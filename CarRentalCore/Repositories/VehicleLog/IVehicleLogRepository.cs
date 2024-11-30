using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;

namespace CarRentalCore.Repositories
{
    public interface IVehicleLogRepository : IRepository<VehicleLog>
    {
        Task<VehicleLog> GetByIdAsync(int id);
        Task<IEnumerable<VehicleLog>> GetAllAsync();
        Task<VehicleLog> AddAsync(VehicleLog vehicleLog);
        Task<VehicleLog> UpdateAsync(VehicleLog vehicleLog);
        Task<bool> DeleteAsync(int id);
    }
}
