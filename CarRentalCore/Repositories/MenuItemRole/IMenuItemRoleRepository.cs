using System.Linq.Expressions;

namespace CarRentalCore.Repositories
{
    public interface IMenuItemRoleRepository : IBaseRepository<MenuItemRole>
    {
        Task<List<MenuItemRole>> GetAllAsync(Expression<Func<MenuItemRole, bool>> predicate);
    }
}   