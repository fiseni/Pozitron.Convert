# Pozitron.Convert

A lightweight .NET library providing safe, null-tolerant conversion extension methods for `string` and `object` types. Conversion failures never throw — a `default` or `null` value is returned instead.

## Installation

```bash
dotnet add package Pozitron.Convert
```

## Target Frameworks

| Framework | Notes |
|-----------|-------|
| .NET Standard 2.0 | String extensions support a fixed set of types |
| .NET 10.0 | String extensions support any `IParsable<T>` type |

## Usage

### Converting strings

```csharp
// Returns the default(T) when conversion fails or input is null
int count = "42".To<int>();
decimal price = "1.99".To<decimal>();

// Returns a custom default when conversion fails or input is null
int count = "abc".To<int>(defaultValue: -1);

// Returns null when conversion fails or input is null
int? count = "abc".ToNullable<int>();
decimal? price = "1.99".ToNullable<decimal>();
```

On .NET 10, `To<T>` and `ToNullable<T>` accept any type implementing `IParsable<T>`, such as `Guid`, `DateOnly`, `TimeOnly`, `DateTimeOffset`, and all numeric types.

```csharp
var id = "d3b07384-d9a0-4f3a-8d1b-2e4f6c8a1b3d".To<Guid>();
var date = "2024-01-15".To<DateOnly>();
```

### Converting objects

Particularly useful in desktop/WinForms applications where UI controls return `object` values.

```csharp
double qty = controlValue.EditValue.To<double>();
int id = controlValue2.EditValue.To<int>(defaultValue: 0);
string? name = controlValue3.EditValue.To<string>();
int? nullableId = controlValue4.EditValue.ToNullable<int>();
```

### Culture-aware conversion

Both `string` and `object` extension methods accept an optional `IFormatProvider`.

```csharp
var price = "1,99".To<decimal>(provider: new CultureInfo("de-DE"));
var date = "01.01.2024".To<DateTime>(provider: new CultureInfo("de-DE"));
```

## API

### String Extensions

Extension methods on `string?`.

| TFM | Method | Returns |
|--------|--------|-----------|
| (.NET 10) | `T? To<T>(this string? value, T? defaultValue = default, IFormatProvider? provider = null) where T : IParsable<T>` | Parsed value, or `defaultValue` on failure/null |
| (.NET 10) | `T? ToNullable<T>(this string? value, IFormatProvider? provider = null) where T : struct, IParsable<T>` | Parsed value, or `null` on failure/null |
| (.NET Standard 2.0) | `T To<T>(this string? value, T defaultValue = default) where T : struct` | Parsed value, or `defaultValue` on failure/null |
| (.NET Standard 2.0) | `T? ToNullable<T>(this string? value) where T : struct` | Parsed value, or `null` on failure/null |

> On .NET Standard 2.0, string extensions support: `int`, `decimal`, `double`, `float`, `DateTime`, `bool`.

### Object Extensions

Extension methods on `object?`. Uses `System.Convert.ChangeType` internally and supports any `IConvertible` type, including `string`.

| Method | Returns |
|--------|---------|
| `T? To<T>(this object? value, T? defaultValue = default, IFormatProvider? provider = null) where T : IConvertible` | Converted value, or `defaultValue` on failure/null |
| `T? ToNullable<T>(this object? value, IFormatProvider? provider = null) where T : struct, IConvertible` | Converted value, or `null` on failure/null |

The `To<T>` methods are annotated with `[NotNullIfNotNull(nameof(defaultValue))]` for accurate nullable static analysis on .NET 10.

## Give a Star! :star:
If you find this library useful, please give it a star. Thanks!

