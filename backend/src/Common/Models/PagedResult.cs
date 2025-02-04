namespace Versta.OrderPlacement.Common.Models;

/// <summary>
/// Результат постраничного запроса
/// </summary>
public sealed record PagedResult<TEntity>(
    IReadOnlyList<TEntity> Items,
    int Total
);
