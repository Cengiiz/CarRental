using CarRentalCore.Models;

namespace CarRentalService.Services
{
    public interface IUserService : IBaseService<User>
    {
        public Task<User> ValidateUser(string userName, string pass);
    }
}