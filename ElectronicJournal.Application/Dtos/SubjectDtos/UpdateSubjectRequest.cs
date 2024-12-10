
namespace ElectronicJournal.Application.Dtos.SubjectDtos
{
    public sealed record UpdateSubjectRequest(Guid SubjectId, string Name, Guid TeacherId);
}
