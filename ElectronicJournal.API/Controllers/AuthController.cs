using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Application.Dtos.ParentDtos;
using ElectronicJournal.Application.Dtos.StudentDtos;
using ElectronicJournal.Application.Dtos.TeacherDtos;
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
        private readonly IParentService _parentService;
        private IStudentService _studentService;
        private ITeacherService _teacherService;
        public AuthController(IAuthService authService)
        {                
            _authService = authService;
        }

        [HttpPost("RegistParents")]
        public async Task<IActionResult> Create([FromBody] CreateParentRequest request, CancellationToken token)
        {
            var x = await _parentService.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPost("RegistStudents")]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequest request, CancellationToken token)
        {
            var x = await _studentService.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPost("RegistTeacher")]
        public async Task<IActionResult> Create([FromBody] CreateTeacherRequest request, CancellationToken token)
        {
            var x = await _teacherService.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(request.Email, request.Password);
            return Ok(response);
        }
    }
}
