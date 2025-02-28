namespace ElectronicJournal.Application.Dtos.SchoolDtos;

public sealed record UpdateSchoolRequest(Guid SchoolId, string Name, string Address, string? Description);