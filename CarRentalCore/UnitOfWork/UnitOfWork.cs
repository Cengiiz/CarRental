using CarRentalCore.Data;
using CarRentalCore.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Users = new UserRepository(_context);
        Roles = new RoleRepository(_context);
        UserRoles = new UserRoleRepository(_context);
        Vehicles = new VehicleRepository(_context);
        VehicleLogs = new VehicleLogRepository(_context);
    }

    public IUserRepository Users { get; private set; }
    public IRoleRepository Roles { get; private set; }
    public IUserRoleRepository UserRoles { get; private set; }
    public IVehicleRepository Vehicles { get; private set; }
    public IVehicleLogRepository VehicleLogs { get; private set; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
