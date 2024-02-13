using Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(UserViewModel userViewModel);
        Task<User> UpdateAsync(UserViewModel userViewModel, int id);
        Task<User> DeleteAsync(int id);
    }
}
