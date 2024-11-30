using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public interface IVehicleService
    {
        Task<Vehicle> GetByIdAsync(int id);
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle> CreateAsync(Vehicle vehicle);
        Task<Vehicle> UpdateAsync(Vehicle vehicle);
        Task<bool> DeleteAsync(int id);
    }
}
