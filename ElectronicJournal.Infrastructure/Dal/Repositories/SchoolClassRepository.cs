using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;

namespace ElectronicJournal.Infrastructure.Dal.Repositories;

public class SchoolClassRepository(ElectronicJornalDbContext context)
    : BaseRepository<SchoolClass>(context), ISchoolClassRepository;