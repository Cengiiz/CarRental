using CarRentalCore.Models;

namespace CarRentalCore.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            // Eğer veritabanında veriler varsa, işlemi durdur
            if (context.Users.Any() || context.Roles.Any() || context.Vehicles.Any()) return;

            // Roller oluşturuluyor
            var roles = new List<Role>
            {
                new Role { Name = "Admin", Description = "Administrator with full access" },
                new Role { Name = "User", Description = "Regular user with limited access" }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();
            // Kullanıcılar oluşturuluyor
            var users = new List<User>
            {
                new User { UserName = "admin",PasswordHash="123456", Email = "admin@carrental.com", FirstName = "Admin", LastName = "User", IsActive = true },
                new User { UserName = "ahmet", PasswordHash="123456",Email = "ahmet@carrental.com", FirstName = "Ahmet", LastName = "Kaya", IsActive = true },
                new User { UserName = "mehmet",PasswordHash="123456", Email = "mehmet@carrental.com", FirstName = "Mehmet", LastName = "Yılmaz", IsActive = true },
                new User { UserName = "ayse", PasswordHash="123456",Email = "ayse@carrental.com", FirstName = "Ayşe", LastName = "Öztürk", IsActive = true }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
            // Kullanıcı - Rol ilişkileri (UserRoles) oluşturuluyor
            var userRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 }, // Admin - Admin rolü
                new UserRole { UserId = 2, RoleId = 2 }, // Ahmet - User rolü
                new UserRole { UserId = 3, RoleId = 2 }, // Mehmet - User rolü
                new UserRole { UserId = 4, RoleId = 2 }  // Ayşe - User rolü
            };
            context.UserRoles.AddRange(userRoles);
            context.SaveChanges();
            // Araçlar oluşturuluyor
            var vehicles = new List<Vehicle>
            {
                new Vehicle { Name = "Ford Focus", LicensePlate = "34ABC123" },
                new Vehicle { Name = "Toyota Corolla", LicensePlate = "35XYZ456" },
                new Vehicle { Name = "BMW 3 Series", LicensePlate = "36DEF789" }
            };
            context.Vehicles.AddRange(vehicles);
            context.SaveChanges();
            // Araç Kayıtları (VehicleLogs) oluşturuluyor
            var vehicleLogs = new List<VehicleLog>
            {
                new VehicleLog { VehicleId = 1, ActiveWorkingHours = 100, MaintenanceHours = 10, IdleHours = 50, LogDate = DateTime.Now },
                new VehicleLog { VehicleId = 2, ActiveWorkingHours = 150, MaintenanceHours = 20, IdleHours = 60, LogDate = DateTime.Now },
                new VehicleLog { VehicleId = 3, ActiveWorkingHours = 200, MaintenanceHours = 30, IdleHours = 80, LogDate = DateTime.Now }
            };
            context.VehicleLogs.AddRange(vehicleLogs);

            // Veritabanına kaydediliyor
            context.SaveChanges();
        }
    }
}
