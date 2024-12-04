using CarRentalService.DTOs;

namespace CarRentalMVC.Services
{
    public interface IMenuService
    {
        Task<List<MenuItemDto>> GetMenuItemsAsync();
        Task<List<MenuItemDto>> GetUserMenuItemsAsync(int id);
    }
}
