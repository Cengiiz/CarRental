namespace CarRentalService.DTOs
{
    public class MenuItemDto : BaseModelDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int? ParentMenuItemId { get; set; }

    }
}

