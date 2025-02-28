namespace ElectronicJournal.Application.Dtos.AttendanceDtos;

public sealed record AttendanceResponse(Guid AttendanceId, Guid StudentId, DateTime Date, bool Status);