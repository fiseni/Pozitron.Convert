namespace Tests;

public class ToStringTests
{
    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("  ", "  ")]
    [InlineData("asd", "asd")]
    public void Tostring_ReturnsExpectedValue_GivenObject(object? input, string? expected)
    {
        var result = input.To<string>();

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, "x", "x")]
    [InlineData("", "x", "")]
    [InlineData("  ", "x", "  ")]
    [InlineData("asd", "x", "asd")]
    public void TostringWithDefaultValue_ReturnsExpectedValue_GivenObject(object? input, string defaultValue, string expected)
    {
        var result = input.To<string>(defaultValue);

        result.Should().Be(expected);
    }
}
