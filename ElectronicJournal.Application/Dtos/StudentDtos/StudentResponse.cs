
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Dtos.StudentDtos
{
    public sealed record StudentResponse(Guid StudentId, FullName FullName,DateTime? DateOfBith, Guid SchoolClassId, string? Description);
}
