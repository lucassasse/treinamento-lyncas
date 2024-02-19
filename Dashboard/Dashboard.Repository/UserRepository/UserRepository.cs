using Dashboard.Domain.Data;
using Domain.Data;
using Dashboard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repository.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.User.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<User> Create(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
