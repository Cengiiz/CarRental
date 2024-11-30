using CarRentalCore.DTOs;
using CarRentalCore.Models;

namespace CarRentalCore.Mappers
{
    public class RoleMapper : IMapper<Role, RoleDto>
    {
        public RoleDto MapToDto(Role entity) => new RoleDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            UserRoles = entity.UserRoles?.Select(ur => new UserRoleDto
            {
                Id = ur.Id,
                UserId = ur.UserId,
                RoleId = ur.RoleId,
                
            }).ToList()
        };

        public Role MapToEntity(RoleDto dto)
        {
            return new Role
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
