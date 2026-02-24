namespace Tests;

public class ToDecimalTests
{
    // We must use member data so we can pass expected values as decimal

    public static TheoryData<string?, decimal> StringToDecimalData => new()
    {
        { null, 0.00m },
        { "asd", 0.00m },
        { "0.00", 0.00m },
        { "1.23", 1.23m },
        { "-1.00", -1.00m },
    };

    [Theory]
    [MemberData(nameof(StringToDecimalData))]
    public void ToDecimal_ReturnsExpectedValue_GivenString(string? input, decimal expected)
    {
        var result = input.To<decimal>();

        result.Should().Be(expected);
    }

    public static TheoryData<string?, decimal, decimal> StringToDecimalDataWithDefaultValue => new()
    {
        { null, 5.00m, 5.00m },
        { "asd", 5.00m, 5.00m },
        { "0.00", 5.00m, 0.00m },
        { "1.23", 5.00m, 1.23m },
        { "-1.00", 5.00m, -1.00m },
    };

    [Theory]
    [MemberData(nameof(StringToDecimalDataWithDefaultValue))]
    public void ToDecimalWithDefaultValue_ReturnsExpectedValue_GivenString(string? input, decimal defaultValue, decimal expected)
    {
        var result = input.To<decimal>(defaultValue);

        result.Should().Be(expected);
    }

    public static TheoryData<string?, decimal?> StringToDecimalOrNullData => new()
    {
        { null, null },
        { "asd", null },
        { "0.00", 0.00m },
        { "1.23", 1.23m },
        { "-1.00", -1.00m },
    };

    [Theory]
    [MemberData(nameof(StringToDecimalOrNullData))]
    public void ToDecimalOrNull_ReturnsExpectedValue_GivenString(string? input, decimal? expected)
    {
        var result = input.ToNullable<decimal>();

        result.Should().Be(expected);
    }

    public static TheoryData<string?, decimal> ObjectToDecimalData => new()
    {
        { null, 0.00m },
        { "asd", 0.00m },
        { "0.00", 0.00m },
        { "1.23", 1.23m },
        { "-1.00", -1.00m },
    };

    [Theory]
    [MemberData(nameof(ObjectToDecimalData))]
    public void ToDecimal_ReturnsExpectedValue_GivenObject(object? input, decimal expected)
    {
        var result = input.To<decimal>();

        result.Should().Be(expected);
    }

    public static TheoryData<string?, decimal, decimal> ObjectToDecimalDataWithDefaultValue => new()
    {
        { null, 5.00m, 5.00m },
        { "asd", 5.00m, 5.00m },
        { "0.00", 5.00m, 0.00m },
        { "1.23", 5.00m, 1.23m },
        { "-1.00", 5.00m, -1.00m },
    };

    [Theory]
    [MemberData(nameof(ObjectToDecimalDataWithDefaultValue))]
    public void ToDecimalWithDefaultValue_ReturnsExpectedValue_GivenObject(object? input, decimal defaultValue, decimal expected)
    {
        var result = input.To<decimal>(defaultValue);

        result.Should().Be(expected);
    }

    public static TheoryData<string?, decimal?> ObjectToDecimalOrNullData => new()
    {
        { null, null },
        { "asd", null },
        { "0.00", 0.00m },
        { "1.23", 1.23m },
        { "-1.00", -1.00m },
    };

    [Theory]
    [MemberData(nameof(ObjectToDecimalOrNullData))]
    public void ToDecimalOrNull_ReturnsExpectedValue_GivenObject(object? input, decimal? expected)
    {
        var result = input.ToNullable<decimal>();

        result.Should().Be(expected);
    }
}
