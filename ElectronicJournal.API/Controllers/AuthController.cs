using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginRequest request)
            {
                var response = await _authService.LoginAsync(request.Email, request.Password);
                return Ok(response);
            }
    }
}
