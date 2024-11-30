using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Models;
using CarRentalCore.Repositories;

namespace CarRentalCore.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _userRoleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _userRoleRepository.GetAllAsync();
        }

        public async Task<UserRole> CreateAsync(UserRole userRole)
        {
            return await _userRoleRepository.AddAsync(userRole);
        }

        public async Task<UserRole> UpdateAsync(UserRole userRole)
        {
            return await _userRoleRepository.UpdateAsync(userRole);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRoleRepository.DeleteAsync(id);
        }
    }
}
