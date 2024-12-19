using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    public interface IAuthController
    {
        Task<IActionResult> Login([FromBody] LoginRequest request, [FromServices] AuthService service);
        Task<IActionResult> Registration([FromBody] RegisterRequest request, [FromServices] AuthService service);
    }
}