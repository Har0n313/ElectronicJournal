
using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.TeacherDtos
{
    public sealed record SearchTeacherRequest(string? FirstName = null, string? LastName = null, string? MiddleName = null, string? AcademicDegree = null, Guid? SchoolId = null)
    {
        public ODataQueryOptions<T> ToODataQueryOptions<T>()
        {
            throw new NotImplementedException();
        }
    }
}
