using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;

namespace ElectronicJournal.Infrastructure.Dal.Repositories;

public class AttendanceRepository(ElectronicJornalDbContext context)
    : BaseRepository<Attendance>(context), IAttendanceRepository;