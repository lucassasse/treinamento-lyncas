using Dashboard.Domain.Models;
using AutoMapper;
using Dashboard.Domain.ViewModels;
using Dashboard.Service.Service;
using Dashboard.Domain.Dtos;
using Dashboard.Repository.UserRepository;

namespace Dashboard.Service.UserService
{
    public class UserService : Service<User, UserDto, UserViewModel, IUserRepository>, IUserService
    {

        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<UserViewModel>> GetAsync()
        {
            try
            {
                var user = await Task.FromResult(_repository.GetAll().ToList());
                var userViewModel = _mapper.Map<List<UserViewModel>>(user);
                return userViewModel;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while getting users.", ex);
            }
        }
    }
}
