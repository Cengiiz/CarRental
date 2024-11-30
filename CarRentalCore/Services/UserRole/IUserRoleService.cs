using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public interface IUserRoleService
    {
        Task<UserRole> GetByIdAsync(int id);
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole> CreateAsync(UserRole userRole);
        Task<UserRole> UpdateAsync(UserRole userRole);
        Task<bool> DeleteAsync(int id);
    }
}
