using Versta.OrderPlacement.Domain.Orders;

namespace Versta.OrderPlacement.Application.Orders;

/// <summary>
/// Репозиторий для работы с заказами
/// </summary>
public interface IOrderRepository : IRepository<Order>;
