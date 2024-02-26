using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;
using Dashboard.Service.Service;

namespace Dashboard.Service.UserService
{
    public interface IUserService : IService<User, UserDto, UserViewModel>
    {
        Task<List<UserViewModel>> GetAsync();
    }
}
