using CarRentalCore.Data;
using CarRentalCore.Models;

namespace CarRentalCore.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
