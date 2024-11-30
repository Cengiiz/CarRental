namespace CarRentalCore.Models
{

    public class Vehicle : BaseModel
    {
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public ICollection<VehicleLog> VehicleWorkLogs { get; set; }
    }


}
