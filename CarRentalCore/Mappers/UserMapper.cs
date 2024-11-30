
using CarRentalCore.DTOs;
using CarRentalCore.Mappers;
using CarRentalCore.Models;

namespace CarRentalCore.Mapper
{
    public class UserMapper : IMapper<User, UserDto>
    {
        public UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                //Role = user.UserRoles != null && user.UserRoles.Count > 0
                //       ? new RoleDto
                //       {
                //           Name = user.UserRoles.First().Role.Name,
                //           Description = user.UserRoles.First().Role.Description
                //       }
                //       : null,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public User MapToEntity(UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                CreatedAt = userDto.CreatedAt,
                UpdatedAt = userDto.UpdatedAt
            };
        }
    }
}
