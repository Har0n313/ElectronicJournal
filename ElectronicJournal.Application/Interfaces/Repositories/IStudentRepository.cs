﻿using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Interfaces.Repositories
{
    public interface IStudentRepository : IRepository<Student>, IRegistrationRepository
    {
    }
}
