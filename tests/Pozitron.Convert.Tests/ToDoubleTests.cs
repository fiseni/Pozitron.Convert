using Pozitron.Convert;
using FluentAssertions;

namespace Tests;

public class ToDoubleTests
{
    [Theory]
    [InlineData(null, 0.00)]
    [InlineData("asd", 0.00)]
    [InlineData("0.00", 0.00)]
    [InlineData("1.23", 1.23)]
    [InlineData("-1.00", -1.00)]
    public void ToDouble_ReturnsExpectedValue_GivenString(string? input, double expected)
    {
        var result = input.To<double>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("asd", null)]
    [InlineData("0.00", 0.00)]
    [InlineData("1.23", 1.23)]
    [InlineData("-1.00", -1.00)]
    public void ToDoubleOrNull_ReturnsExpectedValue_GivenString(string? input, double? expected)
    {
        var result = input.ToNullable<double>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, 0.00)]
    [InlineData("asd", 0.00)]
    [InlineData("0.00", 0.00)]
    [InlineData("1.23", 1.23)]
    [InlineData("-1.00", -1.00)]
    public void ToDouble_ReturnsExpectedValue_GivenObject(object? input, double expected)
    {
        var result = input.To<double>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("asd", null)]
    [InlineData("0.00", 0.00)]
    [InlineData("1.23", 1.23)]
    [InlineData("-1.00", -1.00)]
    public void ToDoubleOrNull_ReturnsExpectedValue_GivenObject(object? input, double? expected)
    {
        var result = input.ToNullable<double>();

        result.Should().Be(expected);
    }
}
