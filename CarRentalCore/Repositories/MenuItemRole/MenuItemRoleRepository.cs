using CarRentalCore.Data;

namespace CarRentalCore.Repositories
{
    public class MenuItemRoleRepository : BaseRepository<MenuItemRole>, IMenuItemRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
