﻿namespace CarRentalService.DTOs
{
    public class UserRoleDto : BaseModelDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
