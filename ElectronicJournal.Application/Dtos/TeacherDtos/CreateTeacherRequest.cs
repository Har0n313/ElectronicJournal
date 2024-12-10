
namespace ElectronicJournal.Application.Dtos.TeacherDtos
{
    public sealed record CreateTeacherRequest(string FirstName, string LastName, string? MiddleName, DateTime DateOfBith, Guid SchoolId, string AcademicDegree, string? Description);
}
