using CarRentalCore.Models;
using CarRentalCore.DTOs;
using CarRentalCore.Mappers;

namespace CarRentalAPI.Mappers
{
    public class VehicleLogMapper : IMapper<VehicleLog, VehicleLogDto>
    {
        public VehicleLogDto MapToDto(VehicleLog entity)
        {
            return new VehicleLogDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy,
                VehicleId = entity.VehicleId,
                //LicensePlate = entity.Vehicle?.LicensePlate,
                ActiveWorkingHours = entity.ActiveWorkingHours,
                MaintenanceHours = entity.MaintenanceHours,
                IdleHours = entity.IdleHours,
                LogDate = entity.LogDate,
            };
        }

        public VehicleLog MapToEntity(VehicleLogDto dto)
        {
            return new VehicleLog
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                CreatedBy = dto.CreatedBy,
                UpdatedAt = dto.UpdatedAt,
                UpdatedBy = dto.UpdatedBy,
                VehicleId = dto.VehicleId,
                ActiveWorkingHours = dto.ActiveWorkingHours,
                MaintenanceHours = dto.MaintenanceHours,
                IdleHours = dto.IdleHours,
                LogDate = dto.LogDate,
            };
        }
    }
}
