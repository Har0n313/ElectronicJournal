
using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.SchoolClassDtos
{
    public sealed record SearchSchoolClassRequest(string? Name = null, Guid? TeacherId = null, Guid? SchoolId = null)
    {
        public ODataQueryOptions<T> ToODataQueryOptions<T>()
        {
            throw new NotImplementedException();
        }
    }

}
