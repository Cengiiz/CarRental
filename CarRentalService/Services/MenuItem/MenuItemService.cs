namespace CarRentalService.Services
{
    public class MenuItemService : BaseService<MenuItem>, IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
