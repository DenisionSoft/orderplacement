using Microsoft.EntityFrameworkCore;
using Versta.OrderPlacement.Application.Orders;
using Versta.OrderPlacement.Common.Exceptions;
using Versta.OrderPlacement.Common.Models;
using Versta.OrderPlacement.Data.Engine;
using Versta.OrderPlacement.Domain.Orders;

namespace Versta.OrderPlacement.Data.Orders;

internal sealed class OrderRepository : IOrderRepository
{
    private readonly DataContext dbContext;

    public OrderRepository(DataContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<PagedResult<Order>> GetPageAsync(
        int offset,
        int limit,
        CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders.Skip(offset).Take(limit).ToListAsync(cancellationToken);
        return new PagedResult<Order>(orders, dbContext.Orders.Count());
    }

    public async Task<Order> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var entity = await dbContext.Orders
            .Where(o => o.Id == id)
            .SingleOrDefaultAsync(cancellationToken);

        return NotFoundException.ThrowIfNull(entity, $"Заказ «{id}» не найден");
    }

    public async Task AddAsync(
        Order order,
        CancellationToken cancellationToken)
    {
        await dbContext.Orders.AddAsync(order, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

}
