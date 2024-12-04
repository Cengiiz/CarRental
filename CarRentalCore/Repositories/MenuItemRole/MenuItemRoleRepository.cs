using CarRentalCore.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRentalCore.Repositories
{
    public class MenuItemRoleRepository : BaseRepository<MenuItemRole>, IMenuItemRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<MenuItemRole>> GetAllAsync(Expression<Func<MenuItemRole, bool>> predicate)
        {
            return await _context.MenuItemRoles
                .Include(x=>x.MenuItem)
                .Where(predicate)
                .ToListAsync();
        }

    }
}
