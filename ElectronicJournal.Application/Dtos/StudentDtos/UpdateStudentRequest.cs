namespace ElectronicJournal.Application.Dtos.StudentDtos;

public sealed record UpdateStudentRequest(
    Guid StudentId,
    string FirstName,
    string LastName,
    string? MiddleName,
    Guid SchoolClassId,
    string? Description);