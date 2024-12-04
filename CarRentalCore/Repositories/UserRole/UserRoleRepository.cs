using CarRentalCore.Data;
using CarRentalCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRentalCore.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserRole>> GetAllAsync(Expression<Func<UserRole, bool>> predicate)
        {
            return await _context.UserRoles
                .Where(predicate)
                .ToListAsync();
        }
    }
}
