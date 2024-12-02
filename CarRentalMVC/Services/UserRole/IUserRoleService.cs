using CarRentalService.DTOs;

namespace CarRentalMVC.Services
{
    public interface IUserRoleService
    {
        Task<UserRoleDto> GetUserRoleAsync(int id);
        Task<List<UserRoleDto>> GetUserRolesAsync();
        Task<UserRoleDto> UpdateUserRoleAsync(UserRoleDto userDto); 
    }
}
