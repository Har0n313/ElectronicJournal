namespace ElectronicJournal.Application.Dtos.GradeDtos;

public sealed record CreateGradeRequest(Guid StudentId, Guid SubjectId, DateTime Date, int Value, string? Comment);