using ElectronicJournal.Application.Dtos.SubjectDtos;
using ElectronicJournal.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectController(ISubjectService service) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateSubjectRequest request, CancellationToken token)
    {
        var x = await service.CreateAsync(request, token);
        return Ok(x);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateSubjectRequest request, CancellationToken token)
    {
        var x = await service.UpdateAsync(request, token);
        return Ok(x);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById([FromQuery] Guid id, CancellationToken token)
    {
        var x = await service.GetByIdAsync(id, token);
        return Ok(x);
    }

    [HttpGet("GetOdata")]
    public async Task<IActionResult> GetOdata([FromBody] SearchSubjectRequest request, CancellationToken token)
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