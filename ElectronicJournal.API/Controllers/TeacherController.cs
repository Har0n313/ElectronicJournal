using ElectronicJournal.Application.Dtos.TeacherDtos;
using ElectronicJournal.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicJournal.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController(ITeacherService service) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateTeacherRequest request, CancellationToken token)
    {
        var x = await service.CreateAsync(request, token);
        return Ok(x);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateTeacherRequest request, CancellationToken token)
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


    [HttpDelete("Delet")]
    public async Task<IActionResult> Delet(Guid id, CancellationToken token)
    {
        var x = await service.DeleteAsync(id, token);
        return Ok(x);
    }
}