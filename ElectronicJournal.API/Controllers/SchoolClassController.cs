using ElectronicJournal.Application.Dtos.SchoolClassDtos;
using ElectronicJournal.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private readonly ISchoolClassService _service;
        public SchoolClassController(ISchoolClassService service)
        {
            _service = service;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSchoolClassRequest request, CancellationToken token)
        {
            var x = await _service.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSchoolClassRequest request, CancellationToken token)
        {
            var x = await _service.UpdateAsync(request, token);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromBody] Guid Id, CancellationToken token)
        {
            var x = await _service.GetByIdAsync(Id, token);
            return Ok(x);
        }

        [HttpGet("GetOdata")]
        public async Task<IActionResult> GetOdata([FromQuery] SearchSchoolClassRequest request, CancellationToken token)
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
