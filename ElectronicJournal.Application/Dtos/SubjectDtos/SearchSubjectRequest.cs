using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.SubjectDtos;

public sealed record SearchSubjectRequest(string? Name = null, Guid? TeacherId = null)
{
    public ODataQueryOptions<T> ToODataQueryOptions<T>()
    {
        throw new NotImplementedException();
    }
}