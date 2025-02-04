using Versta.OrderPlacement.Common.Models;
using Versta.OrderPlacement.Domain.Orders;

namespace Versta.OrderPlacement.Application.Orders;

/// <summary>
/// Сервис для работы с заказами
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Получить заказ
    /// </summary>
    Task<Order> GetAsync(GetOrderQuery query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить страницу заказов
    /// </summary>
    Task<PagedResult<Order>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создать заказ
    /// </summary>
    Task<Order> CreateOrderAsync(CreateOrderCommand command, CancellationToken cancellationToken = default);
}
