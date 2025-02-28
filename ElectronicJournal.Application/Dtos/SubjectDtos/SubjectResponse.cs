namespace ElectronicJournal.Application.Dtos.SubjectDtos;

public sealed record SubjectResponse(Guid SubjectId, string Name, Guid TeacherId);