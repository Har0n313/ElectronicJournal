using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(string email, string password, FullName fullName, UserRoleEnum role);
        Task<LoginResponse> LoginAsync(string email, string password);
    }
}
