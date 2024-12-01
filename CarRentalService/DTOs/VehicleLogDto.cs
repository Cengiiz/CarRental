using CarRentalCore.Models;

namespace CarRentalService.DTOs
{
    public class VehicleLogDto : BaseModel
    {
        public int VehicleId { get; set; }
        public VehicleDto Vehicle { get; set; }
        public double ActiveWorkingHours { get; set; }
        public double MaintenanceHours { get; set; }
        public double IdleHours { get; set; }
        public DateTime LogDate { get; set; }
    }
}
