using ElectronicJournal.Application.Dtos.TeacherDtos;
using ElectronicJournal.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTeacherRequest request, CancellationToken token)
        {
            var x = await _service.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateTeacherRequest request, CancellationToken token)
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
        public async Task<IActionResult> GetOdata([FromBody] SearchTeacherRequest request, CancellationToken token)
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
