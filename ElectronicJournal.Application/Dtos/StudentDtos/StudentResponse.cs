
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Dtos.StudentDtos;

public sealed record StudentResponse(
    Guid StudentId,
    FullName FullName,
    string Email,
    Guid SchoolClassId,
    string? Description);