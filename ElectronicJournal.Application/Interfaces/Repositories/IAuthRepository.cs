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
        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task RegisterAsync(string email, string password, FullName fullName, UserRoleEnum role);
    }
}
