using CarRentalService.DTOs;
using RestSharp;

namespace CarRentalMVC.Services.Menu
{
    public interface IMenuService
    {
        Task<List<MenuItemDto>> GetMenuItemsAsync(int id);
    }
}
