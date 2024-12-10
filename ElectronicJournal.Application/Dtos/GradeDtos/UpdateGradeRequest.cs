
namespace ElectronicJournal.Application.Dtos.GradeDtos
{
    public sealed record UpdateGradeRequest(Guid GradeId, Guid StudentId, Guid SubjectId, DateTime Date, int Value, string? Comment);
}
