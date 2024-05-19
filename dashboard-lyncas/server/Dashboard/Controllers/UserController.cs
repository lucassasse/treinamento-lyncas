using Dashboard.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult<Response<string>> GetUser()
        {
            Response<string> response = new Response<string>();

            response.Message = "Acesso Realizado!";

            return Ok(response);
        }
    }
}
