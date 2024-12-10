
namespace ElectronicJournal.Application.Dtos.AttendanceDtos
{
    public sealed record UpdateAttendanceRequest(Guid AttendanceId, Guid StudentId, DateTime Date, bool Status);
}
