using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;
using CarRentalCore.Repositories;

namespace CarRentalCore.Services
{
    public class VehicleLogService : IVehicleLogService
    {
        private readonly IVehicleLogRepository _vehicleLogRepository;

        public VehicleLogService(IVehicleLogRepository vehicleLogRepository)
        {
            _vehicleLogRepository = vehicleLogRepository;
        }

        public async Task<VehicleLog> GetByIdAsync(int id)
        {
            return await _vehicleLogRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<VehicleLog>> GetAllAsync()
        {
            return await _vehicleLogRepository.GetAllAsync();
        }

        public async Task<VehicleLog> CreateAsync(VehicleLog vehicleLog)
        {
            return await _vehicleLogRepository.AddAsync(vehicleLog);
        }

        public async Task<VehicleLog> UpdateAsync(VehicleLog vehicleLog)
        {
            return await _vehicleLogRepository.UpdateAsync(vehicleLog);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _vehicleLogRepository.DeleteAsync(id);
        }
    }
}
