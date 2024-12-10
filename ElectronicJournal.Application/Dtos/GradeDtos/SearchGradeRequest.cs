
using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Dtos.GradeDtos
{
    public sealed record SearchGradeRequest(Guid? StudentId = null, Guid? SubjectId = null, DateTime? Date = null, int? MinValue = null, int? MaxValue = null)
    {
        public ODataQueryOptions<T> ToODataQueryOptions<T>()
        {
            throw new NotImplementedException();
        }
    }
}
