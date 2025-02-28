using ElectronicJournal.Application.Dtos.AuthDtos;

namespace ElectronicJournal.Application.Interfaces.Repositories;

public interface IAuthRepository
{
    /// <summary>
    /// Авторизоваться  
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<LoginResponse> LoginAsync(string email, string password);
}
