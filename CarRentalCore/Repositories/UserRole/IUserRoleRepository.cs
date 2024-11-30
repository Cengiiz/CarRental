using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;

namespace CarRentalCore.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        Task<UserRole> GetByIdAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> AddAsync(UserRole userRole);
        Task<UserRole> UpdateAsync(UserRole userRole);
        Task<bool> DeleteAsync(int id);
    }
}
