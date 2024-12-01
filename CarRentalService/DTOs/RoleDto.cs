using CarRentalCore.Models;

namespace CarRentalService.DTOs
{
    public class RoleDto : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
