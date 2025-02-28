using ElectronicJournal.Application.Dtos.AuthDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElectronicJournal.Infrastructure.Dal.Repositories;

public class AuthRepository(ElectronicJornalDbContext context, IConfiguration configuration)
    : IAuthRepository
{
    public async Task<LoginResponse> LoginAsync(string email, string password)
    {
        // Ищем пользователя среди учителей
        var teacher = await context.Teachers.FirstOrDefaultAsync(t => t.Email == email);
        if (teacher != null && BCrypt.Net.BCrypt.Verify(password, teacher.PasswordHash))
        {
            return new LoginResponse(
                Id: teacher.Id,
                Email: teacher.Email,
                Token: GenerateJwtToken(teacher.Id, teacher.Email, "Teacher"),
                Role: UserRoleEnum.Teacher
            );
        }

        // Ищем пользователя среди студентов
        var student = await context.Students.FirstOrDefaultAsync(s => s.Email == email);
        if (student != null && BCrypt.Net.BCrypt.Verify(password, student.PasswordHash))
        {
            return new LoginResponse(
                Id: student.Id,
                Email: student.Email,
                Token: GenerateJwtToken(student.Id, student.Email, "Student"),
                Role: UserRoleEnum.Student
            );
        }

        // Ищем пользователя среди родителей
        var parent = await context.Parents.FirstOrDefaultAsync(p => p.Email == email);
        if (parent != null && BCrypt.Net.BCrypt.Verify(password, parent.PasswordHash))
        {
            return new LoginResponse(
                Id: parent.Id,
                Email: parent.Email,
                Token: GenerateJwtToken(parent.Id, parent.Email, "Parent"),
                Role: UserRoleEnum.Parent
            );
        }

        // Если пользователь не найден
        throw new UnauthorizedAccessException("Invalid email or password.");
    }


    private string GenerateJwtToken(Guid userId, string email, string role)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(3),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
