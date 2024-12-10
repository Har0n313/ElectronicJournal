
using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.SchoolDtos
{
    public sealed record SearchSchoolRequest(string? Name = null, string? Address = null)
    {
        public ODataQueryOptions<T> ToODataQueryOptions<T>()
        {
            throw new NotImplementedException();
        }
    }
}
