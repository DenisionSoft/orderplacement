namespace Versta.OrderPlacement.Contracts.Orders;

/// <summary>
/// Запрос на создание заказа
/// </summary>
public sealed class CreateOrderRequest
{
    /// <summary>
    /// Город отправителя
    /// </summary>
    public string? OriginCity { get; set; }

    /// <summary>
    /// Адрес отправителя
    /// </summary>
    public string? OriginAddress { get; set; }

    /// <summary>
    /// Город получателя
    /// </summary>
    public string? DestinationCity { get; set; }

    /// <summary>
    /// Адрес получателя
    /// </summary>
    public string? DestinationAddress { get; set; }

    /// <summary>
    /// Вес груза
    /// </summary>
    public double? Weight { get; set; }

    /// <summary>
    /// Дата забора груза
    /// </summary>
    public DateTimeOffset? AcceptedAt { get; set; }
}
