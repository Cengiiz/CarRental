using CarRentalService.DTOs;
using RestSharp;

namespace CarRentalMVC.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int id);
        Task<List<UserDto>> GetUsersAsync();
        Task<RestResponse> UpdateUserAsync(UserDto userDto);
        Task<RestResponse> ValidateUser(string userName,string pass);
        
    }
}
