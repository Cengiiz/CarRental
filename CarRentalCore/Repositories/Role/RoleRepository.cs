using CarRentalCore.Data;
using CarRentalCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCore.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
