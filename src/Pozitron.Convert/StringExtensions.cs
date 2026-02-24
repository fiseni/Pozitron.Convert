using System;

namespace Pozitron.Convert;

/// <summary>
/// Conversion extensions to string
/// </summary>
public static class StringExtensions
{
#if NET8_0_OR_GREATER

    /// <summary>
    /// It converts the string value to various IParsable types.
    /// </summary>
    /// <typeparam name="T">The target IParsable type</typeparam>
    /// <param name="value">The string value to be converted.</param>
    /// <param name="defaultValue">The default to be returned if conversion is not successful. By default it's the default type for T.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>On success, it returns the converted value. On failure or null <see href="value" />, it returns the provided default value or the default value for T.</returns>
    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
    public static T? To<T>(this string? value, T? defaultValue = default, IFormatProvider? provider = null) where T : IParsable<T>
    {
        if (value is null) return defaultValue;

        return T.TryParse(value, provider, out var output) ? output : defaultValue;
    }

    /// <summary>
    /// It converts the string value to various IParsable struct types.
    /// </summary>
    /// <typeparam name="T">The target IParsable type</typeparam>
    /// <param name="value">The string value to be converted.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>On success, it returns the converted value. On failure or null <see href="value" />, it returns null.</returns>
    public static T? ToNullable<T>(this string? value, IFormatProvider? provider = null) where T : struct, IParsable<T>
    {
        if (value is null) return null;

        return T.TryParse(value, provider, out var output) ? output : null;
    }
#else

    /// <summary>
    /// It converts the string value to various struct types.
    /// </summary>
    /// <typeparam name="T">Supported types: int, decimal, double, float, DateTime, bool</typeparam>
    /// <param name="value">The string value to be converted.</param>
    /// <param name="defaultValue">The default to be returned if conversion is not successful. By default it's the default type for T.</param>
    /// <returns>On success, it returns the converted value. On failure or null <see href="value" />, it returns the provided default value or the default value for T.</returns>
    public static T To<T>(this string? value, T defaultValue = default) where T : struct
    {
        if (value is null) return defaultValue;

        // In NetFX 4.8 there is no IParsable interface, so we have to do this manually.
        return typeof(T) switch
        {
            Type type when type == typeof(int) => int.TryParse(value, out var output) && output is T x ? x : defaultValue,
            Type type when type == typeof(decimal) => decimal.TryParse(value, out var output) && output is T x ? x : defaultValue,
            Type type when type == typeof(double) => double.TryParse(value, out var output) && output is T x ? x : defaultValue,
            Type type when type == typeof(float) => float.TryParse(value, out var output) && output is T x ? x : defaultValue,
            Type type when type == typeof(DateTime) => DateTime.TryParse(value, out var output) && output is T x ? x : defaultValue,
            Type type when type == typeof(bool) => bool.TryParse(value, out var output) && output is T x ? x : defaultValue,
            _ => defaultValue
        };
    }

    /// <summary>
    /// It converts the string value to various struct types.
    /// </summary>
    /// <typeparam name="T">Supported types: int, decimal, double, float, DateTime, bool</typeparam>
    /// <param name="value">The string value to be converted.</param>
    /// <returns>On success, it returns the converted value. On failure or null <see href="value" />, it returns null.</returns>
    public static T? ToNullable<T>(this string? value) where T : struct
    {
        if (value is null) return null;

        // In NetFX 4.8 there is no IParsable interface, so we have to do this manually.
        return typeof(T) switch
        {
            Type type when type == typeof(int) => int.TryParse(value, out var output) && output is T x ? x : null,
            Type type when type == typeof(decimal) => decimal.TryParse(value, out var output) && output is T x ? x : null,
            Type type when type == typeof(double) => double.TryParse(value, out var output) && output is T x ? x : null,
            Type type when type == typeof(float) => float.TryParse(value, out var output) && output is T x ? x : null,
            Type type when type == typeof(DateTime) => DateTime.TryParse(value, out var output) && output is T x ? x : null,
            Type type when type == typeof(bool) => bool.TryParse(value, out var output) && output is T x ? x : null,
            _ => null
        };
    }
#endif
}
