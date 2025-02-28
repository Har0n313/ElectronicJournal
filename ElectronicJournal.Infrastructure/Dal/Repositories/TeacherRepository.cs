using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Infrastructure.Dal.Repositories;

public class TeacherRepository(ElectronicJornalDbContext context) : BaseRepository<Teacher>(context), ITeacherRepository
{
    private readonly ElectronicJornalDbContext _context = context;

    public async Task<bool> IsEmailTakenAsync(string email, CancellationToken token)
    {
        return await _context.Parents.AnyAsync(p => p.Email == email, token) ||
               await _context.Teachers.AnyAsync(t => t.Email == email, token) ||
               await _context.Students.AnyAsync(s => s.Email == email, token);
    }
}