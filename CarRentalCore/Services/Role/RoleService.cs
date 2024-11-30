using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Role> GetByIdWithIncludesAsync(int id)
        {
            var entity = await _unitOfWork.RoleRepository.GetByIdWithIncludesAsync(id);
            return entity;
        }
    }
}

