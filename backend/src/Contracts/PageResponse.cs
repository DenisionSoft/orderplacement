namespace Versta.OrderPlacement.Contracts;

/// <summary>
/// Разбитый на страницы ответ
/// </summary>
public sealed class PageResponse<T> : ListResponse<T>
{
    /// <summary>
    /// Количество сущностей
    /// </summary>
    public int? Total { get; set; }
}
