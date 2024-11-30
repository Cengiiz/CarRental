// IRepository.cs
using CarRentalCore.Models;
using System.Linq.Expressions;

namespace CarRentalCore.Repositories
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
