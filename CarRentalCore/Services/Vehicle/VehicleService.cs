using CarRentalCore.Models;

namespace CarRentalCore.Services
{
    public class VehicleService : BaseService<Vehicle>, IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
