namespace Versta.OrderPlacement.Common.Exceptions;

public class ValidationException : Exception
{
    private const string DefaultMessage = "Некорректные данные";

    public ValidationException(string message, Exception? innerException = default)
        : base(message, innerException)
    {
    }

    public static void ThrowIfNot(bool isValid, string message)
    {
        if (!isValid)
        {
            throw new ValidationException(message);
        }
    }

    public static void ThrowIf(bool isNotValid, string message)
    {
        if (isNotValid)
        {
            throw new ValidationException(message);
        }
    }

    public static T ThrowIfNull<T>(T? argument, string message)
        where T : class
        => argument ?? throw new ValidationException(message);

    public static T ThrowIfNull<T>(T? argument, string message)
        where T : struct
        => argument ?? throw new ValidationException(message);
}
