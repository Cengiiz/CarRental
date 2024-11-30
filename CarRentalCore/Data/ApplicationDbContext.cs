using CarRentalCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleLog> VehicleLogs { get; set; }


    }
}
