using Microsoft.Extensions.DependencyInjection;
using Versta.OrderPlacement.Application.Orders;

namespace Versta.OrderPlacement.Application;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// Зарегистрировать сервисы приложения
    /// </summary>
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IOrderService, OrderService>();
    }
}
