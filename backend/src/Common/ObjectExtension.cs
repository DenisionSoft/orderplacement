using System.Runtime.CompilerServices;

namespace Versta.OrderPlacement.Common;

public static class ObjectExtension
{
    public static T Required<T>(this T? value, [CallerArgumentExpression("value")] string? paramName = default)
        where T : class
        => value ?? throw new ArgumentNullException(paramName);

    public static T Required<T>(this T? value, [CallerArgumentExpression("value")] string? paramName = default)
        where T : struct
        => value ?? throw new ArgumentNullException(paramName);
}