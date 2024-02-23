using AutoMapper;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Domain.ViewModels;

namespace Dashboard.Domain.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper() {
            CreateMap<UserDto, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
