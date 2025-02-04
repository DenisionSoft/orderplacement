namespace Versta.OrderPlacement.Domain;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class EntityBase
{
    protected EntityBase(
        Guid id,
        DateTimeOffset createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }

    /// <summary>
    /// Время создания
    /// </summary>
    public DateTimeOffset CreatedAt { get; private set; }
}
