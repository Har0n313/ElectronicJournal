
namespace ElectronicJournal.Application.Dtos.ScheduleDtos
{
    public sealed record CreateScheduleRequest(Guid SchoolClassId, Guid SubjectId, DateTime Date, TimeSpan Time);
}
