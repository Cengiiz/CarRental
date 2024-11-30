using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public class UserRoleService : BaseService<UserRole>, IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


    }
}
