using CarRentalCore.Data;
using CarRentalCore.Models;

namespace CarRentalCore.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
