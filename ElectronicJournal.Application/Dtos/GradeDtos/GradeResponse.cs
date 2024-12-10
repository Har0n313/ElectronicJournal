
namespace ElectronicJournal.Application.Dtos.GradeDtos
{
    public sealed record GradeResponse(Guid GradeId, Guid StudentId, Guid SubjectId, DateTime Date, int Value, string? Comment);
}
