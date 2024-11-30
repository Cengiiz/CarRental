using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
    }
}
