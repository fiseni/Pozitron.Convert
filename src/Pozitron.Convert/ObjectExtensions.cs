using System;

namespace Pozitron.Convert;

/// <summary>
/// Conversion extensions to object
/// </summary>
public static class ObjectExtensions
{
    /// <summary>
    /// It converts the object value to various IConvertible types.
    /// </summary>
    /// <typeparam name="T">The target IConvertible type</typeparam>
    /// <param name="value">The object value to be converted.</param>
    /// <param name="defaultValue">The default to be returned if conversion is not successful. By default it's the default type for T.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>On success, it returns the converted value. On failure or null <see href="value" />, it returns the provided default value or the default value for T.</returns>
#if NET8_0_OR_GREATER
    [return: System.Diagnostics.CodeAnalysis.NotNullIfNotNull(nameof(defaultValue))]
#endif
    public static T? To<T>(this object? value, T? defaultValue = default, IFormatProvider? provider = null) where T : IConvertible
    {
        if (value is null) return defaultValue;

        try
        {
            return (T?)System.Convert.ChangeType(value, typeof(T), provider);
        }
        catch (Exception)
        {
        }

        return defaultValue;
    }

    /// <summary>
    /// It converts the object value to various IConvertible struct types.
    /// </summary>
    /// <typeparam name="T">The target IConvertible struct type</typeparam>
    /// <param name="value">The object value to be converted</param>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>On success, it returns the converted value. On failure or null <see href="value" />, it returns null.</returns>
    public static T? ToNullable<T>(this object? value, IFormatProvider? provider = null) where T : struct, IConvertible
    {
        if (value is null) return null;

        try
        {
            return (T)System.Convert.ChangeType(value, typeof(T), provider);
        }
        catch (Exception)
        {
        }

        return null;
    }
}

