namespace CarRentalService.DTOs
{
    public class VehicleDto : BaseModelDto
    {
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public ICollection<VehicleLogDto>? VehicleWorkLogs { get; set; }
    }
}
