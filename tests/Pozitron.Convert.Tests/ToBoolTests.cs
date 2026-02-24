using Pozitron.Convert;
using FluentAssertions;

namespace Tests;

public class ToBoolTests
{
    [Theory]
    [InlineData(null, false)]
    [InlineData("asd", false)]
    [InlineData("False", false)]
    [InlineData("false", false)]
    [InlineData("True", true)]
    [InlineData("true", true)]
    public void ToBool_ReturnsExpectedValue_GivenString(string? input, bool expected)
    {
        var result = input.To<bool>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, false, false)]
    [InlineData(null, true, true)]
    [InlineData("asd", false, false)]
    [InlineData("asd", true, true)]
    [InlineData("False", true, false)]
    [InlineData("false", true, false)]
    [InlineData("True", false, true)]
    [InlineData("true", false, true)]
    public void ToBoolWithDefaultValue_ReturnsExpectedValue_GivenString(string? input, bool defaultValue, bool expected)
    {
        var result = input.To<bool>(defaultValue);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("asd", null)]
    [InlineData("False", false)]
    [InlineData("false", false)]
    [InlineData("True", true)]
    [InlineData("true", true)]
    public void ToBoolOrNull_ReturnsExpectedValue_GivenString(string? input, bool? expected)
    {
        var result = input.ToNullable<bool>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData("asd", false)]
    [InlineData("False", false)]
    [InlineData("false", false)]
    [InlineData("True", true)]
    [InlineData("true", true)]
    [InlineData(1, true)]
    [InlineData(100, true)]
    [InlineData(0, false)]
    public void ToBool_ReturnsExpectedValue_GivenObject(object? input, bool expected)
    {
        var result = input.To<bool>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, false, false)]
    [InlineData(null, true, true)]
    [InlineData("asd", false, false)]
    [InlineData("asd", true, true)]
    [InlineData("False", true, false)]
    [InlineData("false", true, false)]
    [InlineData("True", false, true)]
    [InlineData("true", false, true)]
    [InlineData(1, false, true)]
    [InlineData(100, false, true)]
    [InlineData(0, true, false)]
    public void ToBoolOrDefaultValue_ReturnsExpectedValue_GivenObject(object? input, bool defaultValue, bool expected)
    {
        var result = input.To<bool>(defaultValue);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("asd", null)]
    [InlineData("False", false)]
    [InlineData("false", false)]
    [InlineData("True", true)]
    [InlineData("true", true)]
    public void ToBoolOrNull_ReturnsExpectedValue_GivenObject(object? input, bool? expected)
    {
        var result = input.ToNullable<bool>();

        result.Should().Be(expected);
    }
}
