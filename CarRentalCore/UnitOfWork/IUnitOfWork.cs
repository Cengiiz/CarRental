using CarRentalCore.Repositories;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    IUserRoleRepository UserRoles { get; }
    IVehicleRepository Vehicles { get; }
    IVehicleLogRepository VehicleLogs { get; }
    Task<int> CompleteAsync();
}
