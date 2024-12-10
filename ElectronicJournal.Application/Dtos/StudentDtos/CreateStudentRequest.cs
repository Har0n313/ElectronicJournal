
namespace ElectronicJournal.Application.Dtos.StudentDtos
{
    public sealed record CreateStudentRequest(string FirstName, string LastName, string? MiddleName, DateTime DateofBith, Guid SchoolClassId, string? Description);
}
