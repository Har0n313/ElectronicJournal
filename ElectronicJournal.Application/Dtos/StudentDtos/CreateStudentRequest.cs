
namespace ElectronicJournal.Application.Dtos.StudentDtos
{
    public sealed record CreateStudentRequest(string FirstName, string LastName, string? MiddleName, string Email, string Password, Guid SchoolClassId, string? Description);
}
