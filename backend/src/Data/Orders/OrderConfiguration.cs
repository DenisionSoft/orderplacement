using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Versta.OrderPlacement.Domain.Orders;

namespace Versta.OrderPlacement.Data.Orders;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.OriginCity).IsRequired();
        builder.Property(o => o.OriginAddress).IsRequired();
        builder.Property(o => o.DestinationCity).IsRequired();
        builder.Property(o => o.DestinationAddress).IsRequired();
        builder.Property(o => o.Weight).IsRequired();
        builder.Property(o => o.AcceptedAt).IsRequired();
    }
}
