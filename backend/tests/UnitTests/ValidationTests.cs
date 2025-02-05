using Shouldly;
using Versta.OrderPlacement.Application.Orders;
using Xunit;

namespace Versta.OrderPlacement.UnitTests;

public class ValidationTests
{
    [Theory]
    [MemberData(nameof(InvalidCommandFields))]
    public void CreateOrderCommandValidator_ReturnsFalse_WithInvalidFields(string originCity, string originAddress, double weight)
    {
        // Arrange
        var command = new CreateOrderCommand(
            originCity,
            originAddress,
            "Москва",
            "Сретенский бульвар, 1",
            weight,
            DateTimeOffset.UtcNow);

        var validator = new CreateOrderCommandValidator();

        // Act
        var result = validator.Validate(command);

        // Assert
        result.IsValid.ShouldBe(false);
    }

    public static TheoryData<string, string, double> InvalidCommandFields =>
        new()
        {
            { "", "Невский проспект, 1", 10.0 },
            { "Санкт-Петербург", "", 10.0 },
            { "Санкт-Петербург", "Невский проспект, 1", 0.0 }
        };
}
