using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
