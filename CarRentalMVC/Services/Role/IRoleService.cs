using CarRentalService.DTOs;
using RestSharp;

namespace CarRentalMVC.Services
{
    public interface IRoleService
    {
        Task<RoleDto> GetRoleAsync(int id);
        Task<List<RoleDto>> GetRolesAsync();
        Task<RestResponse> UpdateRoleAsync(RoleDto roleDto);
        Task<RoleDto> ValidateRole(string roleName,string pass);
        
    }
}
