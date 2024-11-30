using CarRentalAPI.Mappers;
using CarRentalCore.DTOs;
using CarRentalCore.Models;

namespace CarRentalCore.Mappers
{
    public class VehicleMapper : IMapper<Vehicle, VehicleDto>
    {
        public VehicleDto MapToDto(Vehicle entity)
        {
            return new VehicleDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy,
                Name = entity.Name,
                LicensePlate = entity.LicensePlate,
                VehicleWorkLogs = entity.VehicleWorkLogs?.Select(vl => new VehicleLogMapper().MapToDto(vl)).ToList()
            };
        }

        public Vehicle MapToEntity(VehicleDto dto)
        {
            return new Vehicle
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                CreatedBy = dto.CreatedBy,
                UpdatedAt = dto.UpdatedAt,
                UpdatedBy = dto.UpdatedBy,
                Name = dto.Name,
                LicensePlate = dto.LicensePlate
            };
        }
    }
}
