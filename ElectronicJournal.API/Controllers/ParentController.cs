using ElectronicJournal.Application.Dtos.ParentDtos;
using ElectronicJournal.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateParentRequest request, [FromServices] ParentService service, CancellationToken token)
        {
            var x = await service.CreateAsync(request, token);
            return Ok(x);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UpdateParentRequest request, [FromServices] ParentService service, CancellationToken token)
        {
            var x = service.UpdateAsync(request, token);
            return Ok(x);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromBody] Guid Id, [FromServices] ParentService service, CancellationToken token)
        {
            var x = service.GetByIdAsync(Id, token);
            return Ok(x);
        }

        [HttpGet("GetOdata")]
        public IActionResult GetOdata([FromBody] SearchParentRequest request, [FromServices] ParentService service, CancellationToken token)
        {
            var x = service.GetOdataAsync(request, token);
            return Ok(x);
        }

        [HttpDelete("Delet")]
        public IActionResult Delet(Guid id, [FromServices] ParentService service, CancellationToken token)
        {
            var x = service.DeleteAsync(id, token);
            return Ok(x);
        }
    }
}
