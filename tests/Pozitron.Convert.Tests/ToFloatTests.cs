using Pozitron.Convert;
using FluentAssertions;

namespace Tests;

public class ToFloatTests
{
    [Theory]
    [InlineData(null, 0.00f)]
    [InlineData("asd", 0.00f)]
    [InlineData("0.00", 0.00f)]
    [InlineData("1.23", 1.23f)]
    [InlineData("-1.00", -1.00f)]
    public void ToFloat_ReturnsExpectedValue_GivenString(string? input, float expected)
    {
        var result = input.To<float>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("asd", null)]
    [InlineData("0.00", 0.00f)]
    [InlineData("1.23", 1.23f)]
    [InlineData("-1.00", -1.00f)]
    public void ToFloatOrNull_ReturnsExpectedValue_GivenString(string? input, float? expected)
    {
        var result = input.ToNullable<float>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, 0.00f)]
    [InlineData("asd", 0.00f)]
    [InlineData("0.00", 0.00f)]
    [InlineData("1.23", 1.23f)]
    [InlineData("-1.00", -1.00f)]
    public void ToFloat_ReturnsExpectedValue_GivenObject(object? input, float expected)
    {
        var result = input.To<float>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("asd", null)]
    [InlineData("0.00", 0.00f)]
    [InlineData("1.23", 1.23f)]
    [InlineData("-1.00", -1.00f)]
    public void ToFloatOrNull_ReturnsExpectedValue_GivenObject(object? input, float? expected)
    {
        var result = input.ToNullable<float>();

        result.Should().Be(expected);
    }
}
