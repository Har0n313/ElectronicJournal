
using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.AttendanceDtos
{
    public sealed record SearchAttendanceRequest(Guid? StudentId = null, DateTime? Date = null, bool? Status = null)
    {
        public ODataQueryOptions<T> ToODataQueryOptions<T>()
        {
            throw new NotImplementedException();
        }
    }
}
