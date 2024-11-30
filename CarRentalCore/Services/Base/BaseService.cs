using CarRentalCore.Models;
using System.Linq.Expressions;

namespace CarRentalCore.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _unitOfWork.GetRepository<T>().GetAllAsync();
            return entities;
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.GetRepository<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.GetRepository<T>().UpdateAsync(entity);

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.GetRepository<T>().DeleteAsync(id);

            return true;
        }
    }
}
