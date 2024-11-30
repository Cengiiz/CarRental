using AutoMapper;
using CarRentalCore.DTOs;
using CarRentalCore.Models;

namespace CarRentalCore.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();
        }
    }
}
