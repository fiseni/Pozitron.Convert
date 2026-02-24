using Pozitron.Convert;
using FluentAssertions;

namespace Tests;

public class ToDateTimeTests
{
    [Theory]
    [InlineData(null, 1, 1, 1)]
    [InlineData("asd", 1, 1, 1)]
    [InlineData("2023-06-15", 2023, 6, 15)]
    public void ToDateTime_ReturnsExpectedValue_GivenString(string? input, int year, int month, int day)
    {
        var expected = new DateTime(year, month, day);
        var result = input.To<DateTime>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("2023-06-15", 2023, 6, 15)]
    public void ToDateTimeOrNull_ReturnsExpectedValue_GivenValidString(string? input, int year, int month, int day)
    {
        var expected = new DateTime(year, month, day);
        var result = input.ToNullable<DateTime>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("asd")]
    public void ToDateTimeOrNull_ReturnsNull_GivenInvalidString(string? input)
    {
        var result = input.ToNullable<DateTime>();

        result.Should().BeNull();
    }

    [Theory]
    [InlineData(null, 1, 1, 1)]
    [InlineData("asd", 1, 1, 1)]
    [InlineData("2023-06-15", 2023, 6, 15)]
    public void ToDateTime_ReturnsExpectedValue_GivenObject(object? input, int year, int month, int day)
    {
        var expected = new DateTime(year, month, day);
        var result = input.To<DateTime>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("2023-06-15", 2023, 6, 15)]
    public void ToDateTimeOrNull_ReturnsExpectedValue_GivenValidObject(object? input, int year, int month, int day)
    {
        var expected = new DateTime(year, month, day);
        var result = input.ToNullable<DateTime>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("asd")]
    public void ToDateTimeOrNull_ReturnsNull_GivenInvalidObject(object? input)
    {
        var result = input.ToNullable<DateTime>();

        result.Should().BeNull();
    }
}
