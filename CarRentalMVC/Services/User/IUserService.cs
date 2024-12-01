using CarRentalService.DTOs;

namespace CarRentalMVC.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync();
    }
}
