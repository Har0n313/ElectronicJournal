namespace ElectronicJournal.Application.Dtos.ScheduleDtos;

public sealed record UpdateScheduleRequest(
    Guid ScheduleId,
    Guid SchoolClassId,
    Guid SubjectId,
    DateTime Date,
    TimeSpan Time);