namespace ElectronicJournal.Application.Dtos.AttendanceDtos;

public sealed record CreateAttendanceRequest(Guid StudentId, DateTime Date, bool Status);