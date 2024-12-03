using CarRentalCore.Data;
using CarRentalCore.Models;
using CarRentalCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    private IQueryable<T> ActiveEntities => _context.Set<T>().Where(e => e.IsActive);

    public async Task<T> AddAsync(T entity)
    {
        entity.IsActive = true;
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await ActiveEntities.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await ActiveEntities.ToListAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null || !entity.IsActive)
        {
            return false;
        }

        entity.IsActive = false;
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await ActiveEntities.Where(predicate).ToListAsync();
    }
}
