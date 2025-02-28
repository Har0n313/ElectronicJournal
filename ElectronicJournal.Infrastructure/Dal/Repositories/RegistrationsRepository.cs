using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Infrastructure.Dal.Repositories;

public class RegistrationsRepository(ElectronicJornalDbContext context) : IRegistrationRepository
{
    public async Task<bool> IsEmailTakenAsync(string email, CancellationToken token)
    {
        return await context.Parents.AnyAsync(p => p.Email == email, token) ||
               await context.Teachers.AnyAsync(t => t.Email == email, token) ||
               await context.Students.AnyAsync(s => s.Email == email, token);
    }
}