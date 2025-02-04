using FluentValidation;
using Versta.OrderPlacement.Contracts;

namespace Versta.OrderPlacement.Web.Infrastructure;

public sealed class PageRequestValidator : AbstractValidator<PageRequest>
{
    public PageRequestValidator()
    {
        RuleFor(p => p.Offset).GreaterThanOrEqualTo(0).When(p => p.Offset.HasValue);
        RuleFor(p => p.Limit).GreaterThan(0).When(p => p.Limit.HasValue);
    }
}
