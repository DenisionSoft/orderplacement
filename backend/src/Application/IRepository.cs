using Versta.OrderPlacement.Common.Models;

namespace Versta.OrderPlacement.Application;

public interface IRepository<TEntity>
{
    Task<PagedResult<TEntity>> GetPageAsync(int offset = 0, int limit = 20, CancellationToken cancellationToken = default);

    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
}
