using CarRentalCore.Models;
using CarRentalService.DTOs;

namespace CarRentalService.Services
{
    public interface IMenuItemService : IBaseService<MenuItem>
    {
        Task<List<MenuItemDto>> GetUserMenuItemsAsync(int userId);
    }
}