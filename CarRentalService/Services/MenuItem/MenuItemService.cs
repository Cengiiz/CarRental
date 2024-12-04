using CarRentalService.DTOs;

namespace CarRentalService.Services
{
    public class MenuItemService : BaseService<MenuItem>, IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<MenuItemDto>> GetUserMenuItemsAsync(int userId)
        {
            // User'ın rollerini al
            var userRoles = await _unitOfWork.UserRoleRepository.GetAllAsync(ur => ur.UserId == userId);

            // Kullanıcının rollerinden menü öğelerini bul
            var roleIds = userRoles.Select(ur => ur.RoleId).ToList();
            var menuItems = await _unitOfWork.MenuItemRoleRepository.GetAllAsync(mir => roleIds.Contains(mir.RoleId));

            // Menü öğelerini dön
            var menuItemDtos = menuItems.Select(m => new MenuItemDto
            {
                Id = m.MenuItem.Id,
                Name = m.MenuItem.Name,
                Url = m.MenuItem.Url,
                ParentMenuItemId = m.MenuItem.ParentMenuItemId,
                CreatedAt = m.MenuItem.CreatedAt,
                CreatedBy = m.MenuItem.CreatedBy,
                IsActive = m.MenuItem.IsActive,
                UpdatedAt = m.MenuItem.UpdatedAt,
                UpdatedBy = m.MenuItem.UpdatedBy
                
            }).ToList();

            return menuItemDtos;
        }
    }
}
