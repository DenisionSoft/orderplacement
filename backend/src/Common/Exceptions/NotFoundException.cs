namespace Versta.OrderPlacement.Common.Exceptions;

public class NotFoundException : ValidationException
{
    public NotFoundException(string message, Exception? innerException = default)
        : base(message, innerException)
    {
    }

    public new static T ThrowIfNull<T>(T? argument, string message)
        where T : class
        => argument ?? throw new NotFoundException(message);

    public new static T ThrowIfNull<T>(T? argument, string message)
        where T : struct
        => argument ?? throw new NotFoundException(message);
}
