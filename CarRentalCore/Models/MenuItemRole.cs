using CarRentalCore.Models;

public class MenuItemRole : BaseModel
{
    public int MenuItemId { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public MenuItem MenuItem { get; set; }
}