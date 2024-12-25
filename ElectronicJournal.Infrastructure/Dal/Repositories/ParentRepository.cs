﻿using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Infrastructure.Dal.Repositories
{
    public class ParentRepository : BaseRepository<Parent>, IParentRepository
    {
        public ParentRepository(ElectronicJornalDbContext context) : base(context)
        {
        }
    }
}
