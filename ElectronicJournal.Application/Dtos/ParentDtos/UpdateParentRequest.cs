namespace ElectronicJournal.Application.Dtos.ParentDtos;

public sealed record UpdateParentRequest(
    Guid ParentId,
    string FirstName,
    string LastName,
    string? MiddleName,
    ICollection<Guid> StudentIds);