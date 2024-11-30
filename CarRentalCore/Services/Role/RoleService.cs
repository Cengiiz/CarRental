using CarRentalCore.Models;
using CarRentalCore.Repositories;

namespace CarRentalCore.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role> CreateAsync(Role role)
        {
            return await _roleRepository.AddAsync(role);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            return await _roleRepository.UpdateAsync(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _roleRepository.DeleteAsync(id);
        }
    }
}
