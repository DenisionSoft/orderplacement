using Microsoft.EntityFrameworkCore;
using Versta.OrderPlacement.Domain.Orders;

namespace Versta.OrderPlacement.Data.Engine;

public sealed class DataContext : DbContext
{
    public DbSet<Order> Orders => Set<Order>();

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}
