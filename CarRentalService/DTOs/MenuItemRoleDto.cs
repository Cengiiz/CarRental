namespace CarRentalService.DTOs
{
    public class MenuItemRoleDto : BaseModelDto
    {
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public RoleDto Role { get; set; }
        public MenuItemDto MenuItem { get; set; }
    }
}
