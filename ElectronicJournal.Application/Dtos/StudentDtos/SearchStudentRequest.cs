using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.StudentDtos;

public sealed record SearchStudentRequest(string? FirstName = null, string? LastName = null, Guid? SchoolClassId = null)
{
    public ODataQueryOptions<T> ToODataQueryOptions<T>()
    {
        throw new NotImplementedException();
    }
}