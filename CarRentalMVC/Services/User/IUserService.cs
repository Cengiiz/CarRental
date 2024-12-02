using CarRentalService.DTOs;

namespace CarRentalMVC.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserAsync(int id);
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto> UpdateAsync(UserDto userDto); 
    }
}
