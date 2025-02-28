using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;

namespace ElectronicJournal.Infrastructure.Dal.Repositories;

public class ScheduleRepository(ElectronicJornalDbContext context)
    : BaseRepository<Schedule>(context), IScheduleRepository;