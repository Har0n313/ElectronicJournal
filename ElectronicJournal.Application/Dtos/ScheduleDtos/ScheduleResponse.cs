namespace ElectronicJournal.Application.Dtos.ScheduleDtos;

public sealed record ScheduleResponse(
    Guid ScheduleId,
    Guid SchoolClassId,
    Guid SubjectId,
    DateTime Date,
    TimeSpan Time);