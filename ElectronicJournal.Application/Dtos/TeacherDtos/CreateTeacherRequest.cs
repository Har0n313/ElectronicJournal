
namespace ElectronicJournal.Application.Dtos.TeacherDtos
{
    public sealed record CreateTeacherRequest(string FirstName, string LastName, string? MiddleName, string Email, string Password, string AcademicDegree, string? Description, Guid SchoolId);
}
