using Dashboard.Domain.Models;

namespace Dashboard.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(User user);
    }
}
