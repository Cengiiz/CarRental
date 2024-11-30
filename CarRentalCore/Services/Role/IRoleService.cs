using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public interface IRoleService : IBaseService<Role>
    {
        Task<Role> GetByIdWithIncludesAsync(int id);
    }
}
