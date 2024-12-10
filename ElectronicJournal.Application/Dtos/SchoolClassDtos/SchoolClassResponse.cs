
namespace ElectronicJournal.Application.Dtos.SchoolClassDtos
{
    public sealed record SchoolClassResponse(Guid SchoolClassId, string Name, string? Description, Guid TeacherId, Guid SchoolId);
}
