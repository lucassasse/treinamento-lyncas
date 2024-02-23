using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Service.UserService
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetAsync();
    }
}
