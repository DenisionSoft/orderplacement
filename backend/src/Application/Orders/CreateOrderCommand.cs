namespace Versta.OrderPlacement.Application.Orders;

/// <summary>
/// Команда на создание заказа
/// </summary>
public sealed record CreateOrderCommand(
    string OriginCity,
    string OriginAddress,
    string DestinationCity,
    string DestinationAddress,
    double Weight,
    DateTimeOffset AcceptedAt
);
