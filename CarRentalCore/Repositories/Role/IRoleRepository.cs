// IRoleRepository.cs
using CarRentalCore.Models;

namespace CarRentalCore.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetByIdAsync(int id);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> AddAsync(Role role);
        Task<Role> UpdateAsync(Role role);
        Task<bool> DeleteAsync(int id);
    }
}
