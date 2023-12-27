using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class UserRepositorie : IUserRepositorie
    {
        private readonly SistemTasksDBContext _dbContext;
        public UserRepositorie(SistemTasksDBContext sistemTasksDBContext)
        {
            _dbContext = sistemTasksDBContext;
        }

        public async Task<UserModel> SearchForId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> SearchAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> Create(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel UserForId = await SearchForId(id);

            if(UserForId == null)
            {
                throw new Exception($"User ID: {id} not found in data base.");
            }

            UserForId.Name = user.Name;
            UserForId.Email = user.Email;

            _dbContext.Users.Update(UserForId);
            await _dbContext.SaveChangesAsync();

            return UserForId;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel UserForId = await SearchForId(id);

            if (UserForId == null)
            {
                throw new Exception($"User ID: {id} not found in data base.");
            }

            _dbContext.Users.Remove(UserForId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
