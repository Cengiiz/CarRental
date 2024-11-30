using CarRentalCore.Data;
using CarRentalCore.Models;

namespace CarRentalCore.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
