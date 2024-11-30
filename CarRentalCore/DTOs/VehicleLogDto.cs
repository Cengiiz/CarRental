using CarRentalCore.Models;

namespace CarRentalCore.DTOs
{
    public class VehicleLogDto : BaseModel
    {
        public int VehicleId { get; set; }
        public string LicensePlate { get; set; }
        public double ActiveWorkingHours { get; set; }
        public double MaintenanceHours { get; set; }
        public double IdleHours { get; set; }
        public DateTime LogDate { get; set; }
        public string Description { get; set; }
    }
}
