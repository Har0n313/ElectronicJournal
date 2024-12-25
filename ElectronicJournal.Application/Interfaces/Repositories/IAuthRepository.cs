using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Авторизоваться  
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<LoginResponse> LoginAsync(string email, string password);
    }
}
