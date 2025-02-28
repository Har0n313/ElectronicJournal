namespace ElectronicJournal.Application.Interfaces.Repositories;

public interface IRegistrationRepository
{
    Task<bool> IsEmailTakenAsync(string email, CancellationToken token);
}