using Microsoft.AspNetCore.OData.Query;

namespace ElectronicJournal.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Получить сущность по её уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Экземпляр сущности или null, если она не найдена.</returns>
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запрос к сущностям с использованием OData-опций.
        /// </summary>
        /// <param name="options">OData-опции для формирования запроса.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Запрос, позволяющий выполнить фильтрацию, сортировку и другие операции.</returns>
        Task<IQueryable<TEntity>> GetQueryableAsync(ODataQueryOptions<TEntity> options, CancellationToken cancellationToken = default);

        /// <summary>
        /// Добавить новую сущность в хранилище.
        /// </summary>
        /// <param name="entity">Экземпляр сущности для добавления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Асинхронная задача.</returns>
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить существующую сущность в хранилище.
        /// </summary>
        /// <param name="entity">Экземпляр сущности для обновления.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Асинхронная задача.</returns>
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удалить сущность из хранилища по идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор сущности.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Асинхронная задача.</returns>
        Task DeleteAsync(TEntity Entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Сохранить изменения в базу данных
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
