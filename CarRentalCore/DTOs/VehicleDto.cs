﻿using CarRentalCore.Models;

namespace CarRentalCore.DTOs
{
    public class VehicleDto : BaseModel
    {
        public string Name { get; set; }
        public string LicensePlate { get; set; }
        public ICollection<VehicleLogDto> VehicleWorkLogs { get; set; }
    }
}
