using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Interfaces.Repositories;

public interface ITeacherRepository : IRepository<Teacher>, IRegistrationRepository
{
}