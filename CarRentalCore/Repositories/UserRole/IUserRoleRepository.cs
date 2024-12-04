using CarRentalCore.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRentalCore.Repositories
{
    public interface IUserRoleRepository : IBaseRepository<UserRole>
    {
        Task<List<UserRole>> GetAllAsync(Expression<Func<UserRole, bool>> predicate);
    }
}
