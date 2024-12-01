using CarRentalCore.Models;

namespace CarRentalService.Services
{
    public interface IRoleService : IBaseService<Role>
    {
        Task<Role> GetByIdWithIncludesAsync(int id);
    }
}
