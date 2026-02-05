using Messenger.Api.Interfaces;
using Messenger.Api.Models.Auth;
using Messenger.Api.Models.Zadachi;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Messenger.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController (IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            string result = await authService.LoginAsync(model);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest(new
                {
                    Status = 400,
                    IsValid = false,
                    Errors = new { Email = "Невірний логін або пароль" }
                });
            }

            return Ok(new
            {
                Token = result
            });
        }

        [HttpPost("register")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            string result = await authService.RegisterAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest(new
                {
                    Status = 400,
                    IsValid = false,
                    Errors = new { Email = "Помилка реєстрації" }
                });
            }
            return Ok(new
            {
                Token = result
            });
        }
    }
}
