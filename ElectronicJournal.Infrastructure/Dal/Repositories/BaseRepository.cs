using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;

namespace ElectronicJournal.Infrastructure.Dal.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;

        protected BaseRepository(ElectronicJornalDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entit =  await _context.Set<T>().AddAsync(entity, cancellationToken);
            return entit.Entity;
        }

        public Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<IQueryable<T>> GetQueryableAsync(ODataQueryOptions<T> options, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Set<T>().AsQueryable();

            if (options != null)
            {
                queryable = options.ApplyTo(queryable) as IQueryable<T>;
            }

            return await Task.FromResult(queryable);
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
