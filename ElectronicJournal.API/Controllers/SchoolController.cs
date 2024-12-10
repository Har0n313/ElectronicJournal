using ElectronicJournal.Application.Dtos.SchoolDtos;
using ElectronicJournal.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSchoolRequest request, [FromServices] SchoolService service, CancellationToken token)
        {
            var x = await service.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateSchoolRequest request, [FromServices] SchoolService service, CancellationToken token)
        {
            var x = service.UpdateAsync(request, token);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] Guid Id, [FromServices] SchoolService service, CancellationToken token)
        {
            var x = service.GetByIdAsync(Id, token);
            return Ok(x);
        }

        [HttpGet("GetOdata")]
        public IActionResult GetOdata([FromBody] SearchSchoolRequest request, [FromServices] SchoolService service, CancellationToken token)
        {
            var x = service.GetOdataAsync(request, token);
            return Ok(x);
        }

        [HttpDelete("Delet")]
        public IActionResult Delet(Guid id, [FromServices] SchoolService service, CancellationToken token)
        {
            var x = service.DeleteAsync(id, token);
            return Ok(x);
        }
    }
}
