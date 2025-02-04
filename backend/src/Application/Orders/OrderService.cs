using FluentValidation;
using Versta.OrderPlacement.Common.Models;
using Versta.OrderPlacement.Domain.Orders;
using ValidationException = Versta.OrderPlacement.Common.Exceptions.ValidationException;

namespace Versta.OrderPlacement.Application.Orders;

internal sealed class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IValidator<CreateOrderCommand> createOrderCommandValidator;

    public OrderService(
        IOrderRepository orderRepository,
        IValidator<CreateOrderCommand> createOrderCommandValidator)
    {
        this.orderRepository = orderRepository;
        this.createOrderCommandValidator = createOrderCommandValidator;
    }

    public Task<Order> GetAsync(GetOrderQuery query, CancellationToken cancellationToken)
    {
        return orderRepository.GetByIdAsync(
            query.OrderId,
            cancellationToken);
    }

    public Task<PagedResult<Order>> GetPageAsync(int offset, int limit, CancellationToken cancellationToken)
    {
        return orderRepository.GetPageAsync(
            offset,
            limit,
            cancellationToken);
    }

    public async Task<Order> CreateOrderAsync(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await createOrderCommandValidator.ValidateAsync(command, cancellationToken);
        ValidationException.ThrowIfNot(validationResult.IsValid, "Введённые данные для создания заказа некорректны");

        var order = Order.Create(
            command.OriginCity,
            command.OriginAddress,
            command.DestinationCity,
            command.DestinationAddress,
            command.Weight,
            command.AcceptedAt
        );

        await orderRepository.AddAsync(order, cancellationToken);

        return order;
    }
}
