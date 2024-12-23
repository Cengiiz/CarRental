﻿namespace CarRentalService.DTOs
{
    public class VehicleLogDto : BaseModelDto
    {
        public int VehicleId { get; set; }
        public VehicleDto Vehicle { get; set; }
        public string VehicleName { get; set; }
        public double ActiveWorkingHours { get; set; }
        public double MaintenanceHours { get; set; }
        public double IdleHours { get; set; }
        public DateTime LogDate { get; set; }
    }
}
