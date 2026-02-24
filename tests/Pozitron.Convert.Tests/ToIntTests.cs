namespace Tests;

public class ToIntTests
{
    [Theory]
    [InlineData(null, 0)]
    [InlineData("asd", 0)]
    [InlineData("1.5", 0)]
    [InlineData("0", 0)]
    [InlineData("123", 123)]
    [InlineData("-10", -10)]
    public void ToInt_ReturnsExpectedValue_GivenString(string? input, int expected)
    {
        var result = input.To<int>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, 5, 5)]
    [InlineData("asd", 5, 5)]
    [InlineData("1.5", 5, 5)]
    [InlineData("0", 5, 0)]
    [InlineData("123", 5, 123)]
    [InlineData("-10", 5, -10)]
    public void ToIntWithDefaultValue_ReturnsExpectedValue_GivenString(string? input, int defaultValue, int expected)
    {
        var result = input.To<int>(defaultValue);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("asd", null)]
    [InlineData("1.5", null)]
    [InlineData("0", 0)]
    [InlineData("123", 123)]
    [InlineData("-10", -10)]
    public void ToIntOrNull_ReturnsExpectedValue_GivenString(string? input, int? expected)
    {
        var result = input.ToNullable<int>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, 0)]
    [InlineData("asd", 0)]
    [InlineData(1.5, 2)]
    [InlineData("0", 0)]
    [InlineData("123", 123)]
    [InlineData("-10", -10)]
    public void ToInt_ReturnsExpectedValue_GivenObject(object? input, int expected)
    {
        var result = input.To<int>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, 5, 5)]
    [InlineData("asd", 5, 5)]
    [InlineData(1.5, 5, 2)]
    [InlineData("0", 5, 0)]
    [InlineData("123", 5, 123)]
    [InlineData("-10", 5, -10)]
    public void ToIntWithDefaultValue_ReturnsExpectedValue_GivenObject(object? input, int defaultValue, int expected)
    {
        var result = input.To<int>(defaultValue);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("asd", null)]
    [InlineData(1.5, 2)]
    [InlineData("0", 0)]
    [InlineData("123", 123)]
    [InlineData("-10", -10)]
    public void ToIntOrNull_ReturnsExpectedValue_GivenObject(object? input, int? expected)
    {
        var result = input.ToNullable<int>();

        result.Should().Be(expected);
    }
}
