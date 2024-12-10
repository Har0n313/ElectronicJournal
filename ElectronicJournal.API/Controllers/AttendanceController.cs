using ElectronicJournal.Application.Dtos.AttendanceDtos;
using ElectronicJournal.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateAttendanceRequest request, [FromServices] AttendanceService service, CancellationToken token)
        {
            var x = await service.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateAttendanceRequest request, [FromServices] AttendanceService service, CancellationToken token)
        {
            var x = service.UpdateAsync(request, token);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] Guid id, [FromServices] AttendanceService service, CancellationToken token)
        {
            var result = await service.GetByIdAsync(id, token);
            return Ok(result);
        }


        [HttpGet("GetOdata")]
        public IActionResult GetOdata([FromBody] SearchAttendanceRequest request, [FromServices] AttendanceService service, CancellationToken token)
        {
            var x = service.GetOdataAsync(request,token);
            return Ok(x);
        }

        [HttpDelete("Delet")]
        public IActionResult Delet(Guid id, [FromServices] AttendanceService service, CancellationToken token)
        {
            var x = service.DeleteAsync(id, token);
            return Ok(x);
        }
    }
}
