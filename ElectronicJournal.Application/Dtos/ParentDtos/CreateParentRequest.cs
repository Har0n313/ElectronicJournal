namespace ElectronicJournal.Application.Dtos.ParentDtos
{
    public sealed record CreateParentRequest(string FirstName, string LastName, string? MiddleName, string Email, string Password , List<Guid>? StudentId);
}
