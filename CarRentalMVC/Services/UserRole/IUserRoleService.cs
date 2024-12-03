using CarRentalService.DTOs;
using RestSharp;

namespace CarRentalMVC.Services
{
    public interface IUserRoleService
    {
        Task<UserRoleDto> GetUserRoleAsync(int id);
        Task<List<UserRoleDto>> GetUserRolesAsync();
        Task<RestResponse> UpdateUserRoleAsync(UserRoleDto userDto); 
    }
}
