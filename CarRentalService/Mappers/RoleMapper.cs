//using CarRentalService.DTOs;
//using CarRentalService.Mapper;
//using CarRentalService.Models;

//namespace CarRentalService.Mappers
//{
//    public class RoleMapper : IMapper<Role, RoleDto>
//    {
//        public RoleDto MapToDto(Role entity) => new RoleDto
//        {
//            Id = entity.Id,
//            Name = entity.Name,
//            Description = entity.Description,
//            UserRoles = entity.UserRoles?.Select(ur => new UserRoleDto
//            {
//                Id = ur.Id,
//                UserId = ur.UserId,
//                RoleId = ur.RoleId,
//                UserName = ur.User.UserName,
//                RoleName = ur.Role.Name,

//            }).ToList()
//        };

//        public Role MapToEntity(RoleDto dto)
//        {
//            return new Role
//            {
//                Id = dto.Id,
//                Name = dto.Name,
//                Description = dto.Description,
//                UserRoles = dto.UserRoles?.Select(ur => new UserRole
//                {
//                    Id = ur.Id,
//                    UserId = ur.UserId,
//                    RoleId = ur.RoleId,
//                    User = new User()
//                    {
//                        Id = ur.UserId,
//                        UserName = ur.UserName,

//                    }
//                    RoleName = ur.RoleName,

//                }).ToList()
//            };
//        }
//    }
//}
