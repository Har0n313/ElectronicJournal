
namespace ElectronicJournal.Application.Dtos.SchoolClassDtos
{
    public sealed record CreateSchoolClassRequest(string Name, string? Description, Guid TeacherId, Guid SchoolId);
}
