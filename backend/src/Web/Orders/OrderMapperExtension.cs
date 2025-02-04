using Versta.OrderPlacement.Application.Orders;
using Versta.OrderPlacement.Common;
using Versta.OrderPlacement.Contracts.Orders;
using Versta.OrderPlacement.Domain.Orders;

namespace Versta.OrderPlacement.Web.Orders;

public static class OrderMapperExtension
{
    public static CreateOrderCommand ToCommand(this CreateOrderRequest request)
    {
        return new CreateOrderCommand
        (
            OriginCity: request.OriginCity.Required(),
            OriginAddress: request.OriginAddress.Required(),
            DestinationCity: request.DestinationCity.Required(),
            DestinationAddress: request.DestinationAddress.Required(),
            Weight: request.Weight.Required(),
            AcceptedAt: request.AcceptedAt.Required()
        );
    }

    public static OrderResponse ToResponse(this Order order)
    {
        return new OrderResponse
        {
            Id = order.Id.ToString(),
            OriginCity = order.OriginCity,
            OriginAddress = order.OriginAddress,
            DestinationCity = order.DestinationCity,
            DestinationAddress = order.DestinationAddress,
            Weight = order.Weight,
            AcceptedAt = order.AcceptedAt
        };
    }
}
