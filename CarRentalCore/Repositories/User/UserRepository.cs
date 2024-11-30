using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalCore.Data;
using CarRentalCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalCore.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AddAsync(User user)
        {
            var createdEntity = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return createdEntity.Entity;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var updatedEntity = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
