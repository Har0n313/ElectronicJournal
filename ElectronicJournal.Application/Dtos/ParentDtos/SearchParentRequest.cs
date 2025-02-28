using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.ParentDtos;

public sealed record SearchParentRequest(
    string? FirstName = null,
    string? LastName = null,
    string? MiddleName = null,
    Guid? StudentId = null)
{
    public ODataQueryOptions<T> ToODataQueryOptions<T>()
    {
        throw new NotImplementedException();
    }
}