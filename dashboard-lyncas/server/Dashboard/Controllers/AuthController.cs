using Dashboard.Domain.Dtos;
using Dashboard.Service.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var response = await _authService.Login(userLogin);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userRegister)
        {
            var response = await _authService.Register(userRegister);

            return Ok(response);
        }
    }
}
