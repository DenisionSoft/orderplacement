namespace Versta.OrderPlacement.Contracts;

/// <summary>
/// Запрос на получение страницы сущностей
/// </summary>
public sealed class PageRequest
{
    /// <summary>
    /// Количество элементов которое нужно пропустить
    /// </summary>
    public int? Offset { get; set; }

    /// <summary>
    /// Количество элементов которое необходимо получить
    /// </summary>
    public int? Limit { get; set; }
}
