using CarRentalCore.Models;

namespace CarRentalService.DTOs
{
    public class UserRoleDto : BaseModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
