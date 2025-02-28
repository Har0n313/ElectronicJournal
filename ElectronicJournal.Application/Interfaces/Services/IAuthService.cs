using ElectronicJournal.Application.Dtos.AuthDtos;

namespace ElectronicJournal.Application.Interfaces.Services;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(string email, string password);
}