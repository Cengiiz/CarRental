using CarRentalCore.DTOs;
using CarRentalCore.Models;

namespace CarRentalCore.Mappers
{
    public class UserRoleMapper : IMapper<UserRole, UserRoleDto>
    {
        public UserRoleDto MapToDto(UserRole entity)
        {
            return new UserRoleDto
            {
                Id = entity.Id,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy,
                UpdatedAt = entity.UpdatedAt,
                UpdatedBy = entity.UpdatedBy,
                UserId = entity.UserId,
                RoleId = entity.RoleId,
                UserName = entity.User?.UserName,
                RoleName = entity.Role?.Name
            };
        }

        public UserRole MapToEntity(UserRoleDto dto)
        {
            return new UserRole
            {
                Id = dto.Id,
                CreatedAt = dto.CreatedAt,
                CreatedBy = dto.CreatedBy,
                UpdatedAt = dto.UpdatedAt,
                UpdatedBy = dto.UpdatedBy,
                UserId = dto.UserId,
                RoleId = dto.RoleId
            };
        }
    }
}
