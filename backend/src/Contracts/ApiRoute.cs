namespace Versta.OrderPlacement.Contracts;

public static class ApiRoute
{
    public const string Root = "api/v1";

    public const string Orders = Root + "/orders";
    public const string Order = Root + "/orders/{orderId}";

    public static string ForOrder(string orderId) => ReplaceUrlSegment(Order, "orderId", orderId);

    private static string ReplaceUrlSegment(string urlTemplate, string name, string value)
    {
        var escapedValue = Uri.EscapeDataString(value);
        return urlTemplate.Replace("{" + name + "}", escapedValue);
    }
}
