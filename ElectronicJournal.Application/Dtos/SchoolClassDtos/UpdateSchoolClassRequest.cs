
namespace ElectronicJournal.Application.Dtos.SchoolClassDtos
{
    public sealed record UpdateSchoolClassRequest(Guid SchoolClassId, string Name, string? Description, Guid TeacherId, Guid SchoolId);
}
