using ElectronicJournal.Application.Dtos.GradeDtos;
using ElectronicJournal.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController(IGradeService service) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateGradeRequest request, CancellationToken token)
    {
        var x = await service.CreateAsync(request, token);
        return Ok(x);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateGradeRequest request, CancellationToken token)
    {
        var x = await service.UpdateAsync(request, token);
        return Ok(x);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] Guid Id, CancellationToken token)
    {
        var x = await service.GetByIdAsync(Id, token);
        return Ok(x);
    }

    [HttpGet("GetOdata")]
    public async Task<IActionResult> GetOdata([FromBody] SearchGradeRequest request, CancellationToken token)
    {
        var x = await service.GetOdataAsync(request, token);
        return Ok(x);
    }

    [HttpDelete("Delet")]
    public async Task<IActionResult> Delet(Guid id, CancellationToken token)
    {
        var x = await service.DeleteAsync(id, token);
        return Ok(x);
    }
}