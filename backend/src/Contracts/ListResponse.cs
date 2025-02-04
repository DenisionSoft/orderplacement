namespace Versta.OrderPlacement.Contracts;

/// <summary>
/// Ответ в виде списка
/// </summary>
public class ListResponse<T>
{
    /// <summary>
    /// Список сущностей
    /// </summary>
    public List<T> Items { get; set; } = new();
}
