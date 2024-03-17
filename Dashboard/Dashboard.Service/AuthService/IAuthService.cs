using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;

namespace Dashboard.Service.AuthService
{
    public interface IAuthService
    {
        Task<Response<UserCreateDto>> Register(UserCreateDto userRegister);
        bool VerifyIfEmailAndUserAlreadyExist(UserCreateDto userRegister);
        Task<Response<string>> Login(UserLoginDto userLogin);
    }
}
