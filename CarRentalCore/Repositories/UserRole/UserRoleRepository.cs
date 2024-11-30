using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Data;
using CarRentalCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCore.Repositories
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserRole> GetByIdAsync(int id)
        {
            return await _context.UserRoles.Include(ur => ur.User).Include(ur => ur.Role).FirstOrDefaultAsync(ur => ur.Id == id);
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.UserRoles.Include(ur => ur.User).Include(ur => ur.Role).ToListAsync();
        }

        public async Task<UserRole> AddAsync(UserRole userRole)
        {
            var createdEntity = await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<UserRole> UpdateAsync(UserRole userRole)
        {
            var updatedEntity = _context.UserRoles.Update(userRole);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userRole = await _context.UserRoles.FindAsync(id);
            if (userRole == null) return false;

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
