using CarRentalCore.Models;

namespace CarRentalCore.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            if (context.Roles.Any()) return;

            var roles = new List<Role>
            {
                new Role { Name = "Admin", Description = "Administrator with full access", IsActive = true },
                new Role { Name = "User", Description = "Regular user with limited access", IsActive = true }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();

            if (context.Users.Any()) return;

            var users = new List<User>
            {
                new User { UserName = "admin", PasswordHash = "123456", Email = "admin@carrental.com", FirstName = "Admin", LastName = "User", IsActive = true },
                new User { UserName = "ahmet", PasswordHash = "123456", Email = "ahmet@carrental.com", FirstName = "Ahmet", LastName = "Kaya", IsActive = true },
                new User { UserName = "mehmet", PasswordHash = "123456", Email = "mehmet@carrental.com", FirstName = "Mehmet", LastName = "Yılmaz", IsActive = true },
                new User { UserName = "ayse", PasswordHash = "123456", Email = "ayse@carrental.com", FirstName = "Ayşe", LastName = "Öztürk", IsActive = true }
            };
            context.Users.AddRange(users);
            context.SaveChanges();

            if (context.UserRoles.Any()) return;

            var userRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 , IsActive = true },
                new UserRole { UserId = 2, RoleId = 2 , IsActive = true },
                new UserRole { UserId = 3, RoleId = 2 , IsActive = true },
                new UserRole { UserId = 4, RoleId = 2 , IsActive = true }
            };
            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();

            if (context.Vehicles.Any()) return;

            var vehicles = new List<Vehicle>
            {
                new Vehicle { Name = "Ford Focus", LicensePlate = "34ABC123", IsActive = true },
                new Vehicle { Name = "Toyota Corolla", LicensePlate = "35XYZ456", IsActive = true },
                new Vehicle { Name = "BMW 3 Series", LicensePlate = "36DEF789", IsActive = true }
            };
            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();

            if (context.VehicleLogs.Any()) return;

            var vehicleLogs = new List<VehicleLog>
            {
                new VehicleLog { VehicleId = 1, ActiveWorkingHours = 100, MaintenanceHours = 10, IdleHours = 50, LogDate = DateTime.Now, IsActive = true },
                new VehicleLog { VehicleId = 2, ActiveWorkingHours = 150, MaintenanceHours = 20, IdleHours = 60, LogDate = DateTime.Now, IsActive = true },
                new VehicleLog { VehicleId = 3, ActiveWorkingHours = 200, MaintenanceHours = 30, IdleHours = 80, LogDate = DateTime.Now, IsActive = true }
            };
            context.VehicleLogs.AddRange(vehicleLogs);
            context.SaveChanges();

            if (context.MenuItems.Any()) return;

            var menuItems = new List<MenuItem>
            {
                new MenuItem { Name = "Araç İşlemleri", Url = "#", ParentMenuItemId = null, IsActive = true },
                new MenuItem { Name = "Araç Kaydı", Url = "/VehicleEdit/0", ParentMenuItemId = 1, IsActive = true },
                new MenuItem { Name = "Araç Listesi", Url = "/VehicleList", ParentMenuItemId = 1, IsActive = true },

                new MenuItem { Name = "Çalışma Süreleri", Url = "#", ParentMenuItemId = null, IsActive = true },
                new MenuItem { Name = "Aktif Çalışma Süreleri", Url = "#", ParentMenuItemId = 4, IsActive = true },
                new MenuItem { Name = "Çalışma Grafikleri", Url = "#", ParentMenuItemId = 4, IsActive = true },

                new MenuItem { Name = "Kullanıcı Yönetimi", Url = "#", ParentMenuItemId = null, IsActive = true },
                new MenuItem { Name = "Kullanıcı Listesi", Url = "/UserList", ParentMenuItemId = 7, IsActive = true },
                new MenuItem { Name = "Rol Yönetimi", Url = "/UserRoleList", ParentMenuItemId = 7, IsActive = true },

                new MenuItem { Name = "Raporlar", Url = "#", ParentMenuItemId = null, IsActive = true },
                new MenuItem { Name = "Haftalık Raporlar", Url = "#", ParentMenuItemId = 10, IsActive = true },
                new MenuItem { Name = "Grafik Raporlar", Url = "#", ParentMenuItemId = 10, IsActive = true }
            };
            context.MenuItems.AddRange(menuItems);
            context.SaveChanges();

            if (context.MenuItemRoles.Any()) return;

            var menuItemRoles = new List<MenuItemRole>
            {
                new MenuItemRole { MenuItemId = 1, RoleId = 1 },
                new MenuItemRole { MenuItemId = 2, RoleId = 1 },
                new MenuItemRole { MenuItemId = 3, RoleId = 1 },
                new MenuItemRole { MenuItemId = 4, RoleId = 1 },
                new MenuItemRole { MenuItemId = 5, RoleId = 1 },
                new MenuItemRole { MenuItemId = 6, RoleId = 1 },
                new MenuItemRole { MenuItemId = 7, RoleId = 1 },
                new MenuItemRole { MenuItemId = 8, RoleId = 1 },
                new MenuItemRole { MenuItemId = 9, RoleId = 1 },
                new MenuItemRole { MenuItemId = 10, RoleId = 1 },
                new MenuItemRole { MenuItemId = 11, RoleId = 1 },
                new MenuItemRole { MenuItemId = 12, RoleId = 1 },

                new MenuItemRole { MenuItemId = 1, RoleId = 2 },
                new MenuItemRole { MenuItemId = 4, RoleId = 2 },
                new MenuItemRole { MenuItemId = 5, RoleId = 2 }
            };
            context.MenuItemRoles.AddRange(menuItemRoles);
            context.SaveChanges();
        }
    }
}
