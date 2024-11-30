namespace CarRentalCore.Models
{
    public class VehicleLog : BaseModel
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public double ActiveWorkingHours { get; set; }
        public double MaintenanceHours { get; set; }
        public double IdleHours { get; set; }
        public DateTime LogDate { get; set; }
    }

}
