using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElectronicJournal.Infrastructure.Dal.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ElectronicJornalDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(ElectronicJornalDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                // Выбрасываем исключение, чтобы прервать выполнение
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var token = GenerateJwtToken(user);

            // Возвращаем результат в случае успешного выполнения
            return new LoginResponse(
                Id: user.Id,
                Email: user.Email,
                Token: token,
                Role: user.Role
            );
        }

        public async Task RegisterAsync(string email, string password, FullName fullName, UserRoleEnum role)
        {
            if (await _context.Users.AnyAsync(u => u.Email == email))
            {
                throw new Exception("User with this email already exists.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Email = email,
                PasswordHash = hashedPassword,
                FullName = fullName,
                Role = role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
