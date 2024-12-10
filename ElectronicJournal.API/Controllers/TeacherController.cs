using ElectronicJournal.Application.Dtos.TeacherDtos;
using ElectronicJournal.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTeacherRequest request, [FromServices] TeacherService service, CancellationToken token)
        {
            var x = await service.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateTeacherRequest request, [FromServices] TeacherService service, CancellationToken token)
        {
            var x = service.UpdateAsync(request, token);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] Guid Id, [FromServices] TeacherService service, CancellationToken token)
        {
            var x = service.GetByIdAsync(Id, token);
            return Ok(x);
        }

        [HttpGet("GetOdata")]
        public IActionResult GetOdata([FromBody] SearchTeacherRequest request, [FromServices] TeacherService service, CancellationToken token)
        {
            var x = service.GetOdataAsync(request, token);
            return Ok(x);
        }

        [HttpDelete("Delet")]
        public IActionResult Delet(Guid id, [FromServices] TeacherService service, CancellationToken token)
        {
            var x = service.DeleteAsync(id, token);
            return Ok(x);
        }
    }
}
