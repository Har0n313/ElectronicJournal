using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AutHController : ControllerBase
        {
            [HttpPost("Login")]
            public async Task<IActionResult> Login([FromBody] LoginRequest request, [FromServices] AuthService service)
            {
                var res = await service.Login(request);
                return Ok(res);
            }

            [HttpPost("Registration")]
            public async Task<IActionResult> Registration([FromBody] RegisterRequest request, [FromServices] AuthService service)
            {
                await service.Registration(request);
                return Ok();
            }
        }
    }
}
