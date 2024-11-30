using CarRentalCore.Models;
using System.Linq.Expressions;

namespace CarRentalCore.Services
{
    public interface IBaseService<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T role);
        Task<T> UpdateAsync(T role);
        Task<bool> DeleteAsync(int id);
    }
}
