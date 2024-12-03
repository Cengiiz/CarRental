using CarRentalCore.Models;
using CarRentalService.DTOs;

namespace CarRentalService.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> ValidateUser(string userName,string pass)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            if (users != null)
            {
                return users.FirstOrDefault(x => x.UserName == userName && x.PasswordHash == pass);
            }
            return new User();
        }
    }
}
