using Dashboard.Service.UserService;
using Dashboard.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Dtos;
using Dashboard.Domain.ViewModels;
using Dashboard.Service.Service;

namespace Dashboard.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IService<User, UserDto, UserViewModel> _service;

        public UserController(IUserService userService, IService<User, UserDto, UserViewModel> service)
        {
            _userService = userService;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> GetAsync()
        {
            try
            {
                var user = await _userService.GetAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in get users. Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Invalid ID");

                var user = _service.GetById(id);
                if (user == null)
                    return NotFound("User not found");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in get user. Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Create(user);
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Invalid model state");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in user create. Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UserDto User, [FromRoute] int id)
        {
            try
            {
                var existingUser = _service.GetById(id);
                if (existingUser == null)
                    return NotFound("User not found");

                var updatedUser = _service.Update(User, id);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in user update. Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var deletedUser = _service.Delete(id);
                if (deletedUser == null)
                    return NotFound("User not found");

                return Ok(deletedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error in user delete. Internal Server Error: {ex.Message}");
            }
        }
    }
}
