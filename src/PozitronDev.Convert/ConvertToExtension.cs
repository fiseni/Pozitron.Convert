using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.Convert
{
    /// <summary>
    /// Container for Object extensions.
    /// </summary>
    public static class ConvertToExtension
    {
        /// <summary>
        /// An entry point to a set of To clauses defined as extension method on Object.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static ConvertTo To(this object input)
        {
            return new ConvertTo(input);
        }

        /// <summary>
        /// Shorthand notation for most common To clauses, defined as direct extension of Object.
        /// Throws an <see cref="InvalidCastException" /> if casting failes or the type is not in the allowed list.
        /// </summary>
        /// <typeparam name="T">Type to convert to. Types: int, int?, long, long?, double, double?, decimal, decimal?, datetime, datetime?.</typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static T To<T>(this object input)
        {
            ConvertTo convertTo = new ConvertTo(input);
            Type itemType = typeof(T);

            if (itemType == typeof(bool))
            {
                return (T)(object)convertTo.Bool;
            }
            else if (itemType == typeof(bool?))
            {
                return (T)(object)convertTo.BoolOrNull;
            }
            else if (itemType == typeof(int))
            {
                return (T)(object)convertTo.Int;
            }
            else if (itemType == typeof(int?))
            {
                return (T)(object)convertTo.IntOrNull;
            }
            else if (itemType == typeof(long))
            {
                return (T)(object)convertTo.Long;
            }
            else if (itemType == typeof(long?))
            {
                return (T)(object)convertTo.LongOrNull;
            }
            else if (itemType == typeof(double))
            {
                return (T)(object)convertTo.Double;
            }
            else if (itemType == typeof(double?))
            {
                return (T)(object)convertTo.DoubleOrNull;
            }
            else if (itemType == typeof(decimal))
            {
                return (T)(object)convertTo.Decimal;
            }
            else if (itemType == typeof(decimal?))
            {
                return (T)(object)convertTo.DecimalOrNull;
            }
            else if (itemType == typeof(DateTime))
            {
                return (T)(object)convertTo.DateTime;
            }
            else if (itemType == typeof(DateTime?))
            {
                return (T)(object)convertTo.DateTimeOrNull;
            }
            else
            {
                throw new InvalidCastException();
            }
        }
    }
}
