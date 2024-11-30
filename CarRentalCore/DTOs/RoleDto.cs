using CarRentalCore.Models;

namespace CarRentalCore.DTOs
{
    public class RoleDto : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
