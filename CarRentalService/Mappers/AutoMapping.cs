using AutoMapper;
using CarRentalCore.Models;
using CarRentalService.DTOs;

namespace CarRentalService.Mapping
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

            CreateMap<Vehicle, VehicleDto>();
            CreateMap<VehicleDto, Vehicle>();

            CreateMap<VehicleLog, VehicleLogDto>();
            CreateMap<VehicleLogDto, VehicleLog>();

        }
    }
}
