using CarRentalCore.Models;

namespace CarRentalService.Services
{
    public class MenuItemRoleService : BaseService<MenuItemRole>, IMenuItemRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemRoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
