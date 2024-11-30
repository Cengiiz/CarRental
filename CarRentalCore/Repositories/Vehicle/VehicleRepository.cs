using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Data;
using CarRentalCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCore.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await _context.Vehicles.Include(v => v.VehicleWorkLogs).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles.Include(v => v.VehicleWorkLogs).ToListAsync();
        }

        public async Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            var createdEntity = await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<Vehicle> UpdateAsync(Vehicle vehicle)
        {
            var updatedEntity = _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return false;

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
