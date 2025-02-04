using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Versta.OrderPlacement.Application.Orders;
using Versta.OrderPlacement.Contracts;
using Versta.OrderPlacement.Contracts.Orders;
using ValidationException = Versta.OrderPlacement.Common.Exceptions.ValidationException;

namespace Versta.OrderPlacement.Web.Orders;

[ApiController]
public sealed class OrderController : ControllerBase
{
    private readonly IOrderService orderService;
    private readonly IValidator<PageRequest> pageRequestValidator;

    public OrderController(
        IOrderService orderService,
        IValidator<PageRequest> pageRequestValidator)
    {
        this.orderService = orderService;
        this.pageRequestValidator = pageRequestValidator;
    }

    /// <summary>
    /// Получить заказ по идентификатору
    /// </summary>
    [HttpGet(ApiRoute.Order, Name = nameof(GetOrder))]
    public async Task<OrderResponse> GetOrder(
        [FromRoute] string orderId,
        CancellationToken cancellationToken)
    {
        var parseResult = Guid.TryParse(orderId, out var parsedOrderId);
        ValidationException.ThrowIfNot(parseResult, "Идентификатор заказа некорректен");

        var query = new GetOrderQuery(parsedOrderId);
        var order = await orderService.GetAsync(query, cancellationToken);

        return order.ToResponse();
    }

    /// <summary>
    /// Получить страницу заказов
    /// </summary>
    [HttpGet(ApiRoute.Orders, Name = nameof(GetOrders))]
    public async Task<PageResponse<OrderResponse>> GetOrders(
        [FromQuery] PageRequest request,
        CancellationToken cancellationToken)
    {
        var validationResult = await pageRequestValidator.ValidateAsync(request, cancellationToken);
        ValidationException.ThrowIfNot(validationResult.IsValid, "Введённые значения для постраничного запроса некорректны");

        var page = await orderService.GetPageAsync(request.Offset ?? 0, request.Limit ?? 20, cancellationToken);

        var response = new PageResponse<OrderResponse>
            {
                Items = page.Items.Select(o => o.ToResponse()).ToList(),
                Total = page.Total
            };

        return response;
    }

    /// <summary>
    /// Создать заказ
    /// </summary>
    [HttpPost(ApiRoute.Orders, Name = nameof(CreateOrder))]
    public async Task<ActionResult<OrderResponse>> CreateOrder(
        [FromBody] CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        var order = await orderService.CreateOrderAsync(command, cancellationToken);
        return Created(ApiRoute.ForOrder(order.Id.ToString()), order.ToResponse());
    }
}
