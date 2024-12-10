
namespace ElectronicJournal.Application.Dtos.SchoolDtos
{
    public sealed record SchoolResponse(Guid SchoolId, string Name, string Address, string? Description);
}
