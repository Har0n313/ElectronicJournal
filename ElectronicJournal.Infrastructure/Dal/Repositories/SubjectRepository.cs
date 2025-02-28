using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;

namespace ElectronicJournal.Infrastructure.Dal.Repositories;

public class SubjectRepository(ElectronicJornalDbContext context) : BaseRepository<Subject>(context), ISubjectRepository;