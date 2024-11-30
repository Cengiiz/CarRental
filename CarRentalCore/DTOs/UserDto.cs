using CarRentalCore.Models;

namespace CarRentalCore.DTOs
{
    public class UserDto : BaseModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleDto Role { get; set; }
    }
}
