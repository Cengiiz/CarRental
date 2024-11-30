using CarRentalCore.Data;
using CarRentalCore.Models;

namespace CarRentalCore.Repositories
{
    public class VehicleLogRepository : BaseRepository<VehicleLog>, IVehicleLogRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleLogRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
