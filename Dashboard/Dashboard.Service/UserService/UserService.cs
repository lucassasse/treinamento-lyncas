using Dashboard.Domain.Models;
using Dashboard.Domain.Dtos;
using Dashboard.Repository.Repository;
using AutoMapper;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;

        public UserService(IMapper mapper, IRepository<User> repository)
        {
            _mapper = mapper;
            _repository = repository;
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
