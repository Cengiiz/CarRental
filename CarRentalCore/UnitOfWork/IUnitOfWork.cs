using CarRentalCore.Models;
using CarRentalCore.Repositories;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<T> GetRepository<T>() where T : BaseModel;

    IRoleRepository RoleRepository { get; }
    IUserRepository UserRepository { get; }
    IUserRoleRepository UserRoleRepository { get; }
    IVehicleRepository VehicleRepository { get; }
    IVehicleLogRepository VehicleLogRepository { get; }

    IMenuItemRepository MenuItemRepository { get; }
    IMenuItemRoleRepository MenuItemRoleRepository { get; }

    Task<int> CompleteAsync();
}
