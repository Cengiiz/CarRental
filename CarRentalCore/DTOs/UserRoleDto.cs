using CarRentalCore.Models;

namespace CarRentalCore.DTOs
{
    public class UserRoleDto : BaseModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
