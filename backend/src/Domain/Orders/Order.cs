namespace Versta.OrderPlacement.Domain.Orders;

/// <summary>
/// Заказ
/// </summary>
public sealed class Order : EntityBase
{
    private Order(
        Guid id,
        DateTimeOffset createdAt,
        string originCity,
        string originAddress,
        string destinationCity,
        string destinationAddress,
        double weight,
        DateTimeOffset acceptedAt
    ) : base(id, createdAt)
    {
        OriginCity = originCity;
        OriginAddress = originAddress;
        DestinationCity = destinationCity;
        DestinationAddress = destinationAddress;
        Weight = weight;
        AcceptedAt = acceptedAt;
    }

    /// <summary>
    /// Город отправителя
    /// </summary>
    public string OriginCity { get; private set; }

    /// <summary>
    /// Адрес отправителя
    /// </summary>
    public string OriginAddress { get; private set; }

    /// <summary>
    /// Город получателя
    /// </summary>
    public string DestinationCity { get; private set; }

    /// <summary>
    /// Адрес получателя
    /// </summary>
    public string DestinationAddress { get; private set; }

    /// <summary>
    /// Вес груза
    /// </summary>
    public double Weight { get; private set; }

    /// <summary>
    /// Дата забора груза
    /// </summary>
    public DateTimeOffset AcceptedAt { get; private set; }

    public static Order Create(
        string originCity,
        string originAddress,
        string destinationCity,
        string destinationAddress,
        double weight,
        DateTimeOffset acceptedAt)
    {
        var id = Guid.CreateVersion7();
        var createdAt = DateTimeOffset.UtcNow;

        return new Order(
            id,
            createdAt,
            originCity,
            originAddress,
            destinationCity,
            destinationAddress,
            weight,
            acceptedAt.ToUniversalTime()
        );
    }
}
