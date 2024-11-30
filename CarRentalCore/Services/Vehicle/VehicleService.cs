using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;
using CarRentalCore.Repositories;

namespace CarRentalCore.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _vehicleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _vehicleRepository.GetAllAsync();
        }

        public async Task<Vehicle> CreateAsync(Vehicle vehicle)
        {
            return await _vehicleRepository.AddAsync(vehicle);
        }

        public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
        {
            return await _vehicleRepository.UpdateAsync(vehicle);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _vehicleRepository.DeleteAsync(id);
        }
    }
}
