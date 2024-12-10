
using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.ScheduleDtos
{
    public sealed record SearchScheduleRequest(Guid? SchoolClassId = null, Guid? SubjectId = null, DateTime? Date = null, TimeSpan? Time = null)
    {
        public ODataQueryOptions<T> ToODataQueryOptions<T>()
        {
            throw new NotImplementedException();
        }
    }
}
