using ElectronicJournal.Application.Dtos.StudentDtos;
using ElectronicJournal.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequest request, CancellationToken token)
        {
            var x = await _service.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateStudentRequest request, CancellationToken token)
        {
            var x = await _service.UpdateAsync(request, token);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid Id, CancellationToken token)
        {
            var x = await _service.GetByIdAsync(Id, token);
            return Ok(x);
        }

        [HttpGet("GetOdata")]
        public async Task<IActionResult> GetOdata([FromBody] SearchStudentRequest request, CancellationToken token)
        {
            var x = await _service.GetOdataAsync(request, token);
            return Ok(x);
        }

        [HttpDelete("Delet")]
        public async Task<IActionResult> Delet(Guid id, CancellationToken token)
        {
            var x = await _service.DeleteAsync(id, token);
            return Ok(x);
        }
    }
}
