namespace ElectronicJournal.Application.Dtos.ParentDtos
{
    public sealed record CreateParentRequest(string FirstName, string LastName, string? MiddleName, DateTime dateofBith, List<Guid>? StudentId);
}
