// IRepository.cs
using CarRentalCore.Models;

namespace CarRentalCore.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
