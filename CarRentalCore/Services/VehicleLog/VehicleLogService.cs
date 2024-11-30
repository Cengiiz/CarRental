using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public class VehicleLogService : BaseService<VehicleLog>, IVehicleLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleLogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
