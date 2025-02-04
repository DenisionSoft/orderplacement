using FluentValidation;

namespace Versta.OrderPlacement.Application.Orders;

public sealed class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.OriginCity).NotEmpty();
        RuleFor(c => c.OriginAddress).NotEmpty();
        RuleFor(c => c.DestinationCity).NotEmpty();
        RuleFor(c => c.DestinationAddress).NotEmpty();
        RuleFor(c => c.Weight).NotEmpty().GreaterThan(0);
    }
}
