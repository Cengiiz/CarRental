using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Data;
using CarRentalCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCore.Repositories
{
    public class VehicleLogRepository : Repository<VehicleLog>, IVehicleLogRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleLogRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VehicleLog> GetByIdAsync(int id)
        {
            return await _context.VehicleLogs.FindAsync(id);
        }

        public async Task<IEnumerable<VehicleLog>> GetAllAsync()
        {
            return await _context.VehicleLogs.ToListAsync();
        }

        public async Task<VehicleLog> AddAsync(VehicleLog vehicleLog)
        {
            var createdEntity = await _context.VehicleLogs.AddAsync(vehicleLog);
            await _context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<VehicleLog> UpdateAsync(VehicleLog vehicleLog)
        {
            var updatedEntity = _context.VehicleLogs.Update(vehicleLog);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vehicleLog = await _context.VehicleLogs.FindAsync(id);
            if (vehicleLog == null) return false;

            _context.VehicleLogs.Remove(vehicleLog);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
