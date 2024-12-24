using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<LoginResponse> LoginAsync (string email, string password)
        {
            return await _authRepository.LoginAsync(email, password);
        }

        public async Task RegisterAsync(string email, string password, FullName fullName, UserRoleEnum role)
        {
            await _authRepository.RegisterAsync(email, password, fullName, role);
        }
    }
}
