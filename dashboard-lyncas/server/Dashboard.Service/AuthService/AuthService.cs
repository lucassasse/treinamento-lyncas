using Dashboard.Domain.Dtos;
using Dashboard.Domain.Models;
using Dashboard.Service.PasswordService;
using Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordService _passwordService;

        public AuthService(AppDbContext context, IPasswordService passwordService) {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<Response<UserCreateDto>> Register(UserCreateDto userRegister)
        {
            Response<UserCreateDto> responseService = new Response<UserCreateDto>();

            try
            {
                if (!VerifyIfEmailAndUserAlreadyExist(userRegister))
                {
                    responseService.Data = null;
                    responseService.Status = false;
                    responseService.Message = "Email e/ou Usuário já cadastrado.";
                    return responseService;
                }

                _passwordService.CreateHashPassword(userRegister.Password, out byte[] hashPassword, out byte[] saltPassword);

                User user = new User()
                {
                    FullName = userRegister.FullName,
                    Email = userRegister.Email,
                    Position = userRegister.Position,
                    HashPassword = hashPassword,
                    SaltPassword = saltPassword
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                responseService.Message = "Usuário Criado com Sucesso!";

            } 
            catch (Exception ex)
            {
                responseService.Data = null;
                responseService.Message = ex.Message;
                responseService.Status = false;
            }

            return responseService;
        }

        public async Task<Response<string>> Login(UserLoginDto userLogin)
        {
            Response<string> responseService = new Response<string>();

            try
            {
                var user = await _context.User.FirstOrDefaultAsync(userDB => userDB.Email == userLogin.Email);

                if (user == null)
                {
                    responseService.Message = "E-mail ou Senha Inválidos";
                    responseService.Status = false;
                    return responseService;
                }

                if (!_passwordService.VerifyHashPassword(userLogin.Password, user.HashPassword, user.SaltPassword))
                {
                    responseService.Message = "E-mail ou Senha Inválidos";
                    responseService.Status = false;
                    return responseService;
                }

                var token = _passwordService.CreateToken(user);

                responseService.Data = token;
                responseService.Message = "Usuário Logado com Sucesso";

            }
            catch (Exception ex)
            {
                responseService.Data = null;
                responseService.Message = ex.Message;
                responseService.Status = false;
            }

            return responseService;
        }

        public bool VerifyIfEmailAndUserAlreadyExist(UserCreateDto userRegister)
        {
            var user = _context.User.FirstOrDefault(userDB => userDB.Email == userRegister.Email || userDB.FullName == userRegister.FullName);

            if(user != null) return false;

            return true;
        }
    }
}
