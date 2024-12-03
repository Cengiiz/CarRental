using CarRentalCore.Models;

public class MenuItem : BaseModel
{
    public string Name { get; set; }
    public string Url { get; set; }
    public int? ParentMenuItemId { get; set; }
}
