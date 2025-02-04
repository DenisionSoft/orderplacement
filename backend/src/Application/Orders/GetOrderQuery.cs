namespace Versta.OrderPlacement.Application.Orders;

/// <summary>
/// Запрос на получение заказа
/// </summary>
public sealed record GetOrderQuery(Guid OrderId);
