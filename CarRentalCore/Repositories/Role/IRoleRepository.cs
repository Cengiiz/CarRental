using CarRentalCore.Models;
using System.Linq.Expressions;

namespace CarRentalCore.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetByIdWithIncludesAsync(int id);
    }
}
