namespace ElectronicJournal.Application.Dtos.TeacherDtos;

public sealed record UpdateTeacherRequest(
    Guid TeacherId,
    string FirstName,
    string LastName,
    string? MiddleName,
    string AcademicDegree,
    string? Description,
    Guid SchoolId);