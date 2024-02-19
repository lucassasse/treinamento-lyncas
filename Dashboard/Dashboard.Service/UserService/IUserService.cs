using Dashboard.Domain.Models;
using Domain.Models.ViewModels;

namespace Dashboard.Service.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(UserDto userViewModel);
        Task<User> UpdateAsync(UserDto userViewModel, int id);
        Task<User> DeleteAsync(int id);
    }
}
