using CarRentalCore.Data;
using CarRentalCore.Models;
using CarRentalCore.Repositories;
using Microsoft.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        
        RoleRepository = new RoleRepository(_context);
        UserRepository = new UserRepository(_context);
        UserRoleRepository = new UserRoleRepository(_context);
        VehicleRepository = new VehicleRepository(_context);
        VehicleLogRepository = new VehicleLogRepository(_context);
    }

    
    public IRoleRepository RoleRepository { get; }
    public IUserRepository UserRepository { get; }
    public IUserRoleRepository UserRoleRepository { get; }
    public IVehicleRepository VehicleRepository { get; }
    public IVehicleLogRepository VehicleLogRepository { get; }

    
    public IBaseRepository<T> GetRepository<T>() where T : BaseModel
    {
        return new BaseRepository<T>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
