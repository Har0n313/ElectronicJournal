namespace ElectronicJournal.Application.Dtos.SubjectDtos;

public sealed record CreateSubjectRequest(string Name, Guid TeacherId);