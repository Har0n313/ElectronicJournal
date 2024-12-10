
namespace ElectronicJournal.Application.Dtos.StudentDtos
{
    public sealed record UpdateStudentRequest(Guid StudentId, string FirstName, string LastName, string? MiddleName, DateTime DateOfBith, Guid SchoolClassId, string? Description);
}
