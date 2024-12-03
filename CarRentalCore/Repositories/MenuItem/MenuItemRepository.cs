using CarRentalCore.Data;

namespace CarRentalCore.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
