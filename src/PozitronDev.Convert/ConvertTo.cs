using System;
using System.Collections.Generic;
using System.Text;

namespace PozitronDev.Convert
{
    /// <summary>
    /// A collection of common "To" clauses.
    /// </summary>
    public class ConvertTo
    {
        private object input;

        private bool isInputNullOrEmptyString => (input == null || input.ToString() == string.Empty);

        /// <summary>
        /// It requires object value upon which "To" clauses are built.
        /// </summary>
        /// <param name="input"></param>
        public ConvertTo(object input)
        {
            this.input = input;
        }

        /// <summary>
        /// Converts the input to string. If the input is null returns empty string.
        /// </summary>
        public string StringOrEmpty
        {
            get
            {
                return input == null ? string.Empty : input.ToString();
            }
        }

        /// <summary>
        /// Converts the input to string. If the input is null or empty string returns null;
        /// </summary>
        public string StringOrNull
        {
            get
            {
                return (isInputNullOrEmptyString) ? null : input.ToString();
            }
        }

        /// <summary>
        /// Converts the input to a boolean type or throw exception.
        /// Throws an <see cref="FormatException" /> if input is null, empty string, any number or is not in an appropriate format for a boolean type.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        public bool Bool
        {
            get
            {
                if (isInputNullOrEmptyString) throw new FormatException();

                return System.Convert.ToBoolean(input.ToString());
            }
        }

        /// <summary>
        /// Converts the input to a boolean type.
        /// If input is null, empty string, any number or is not in an appropriate format for a boolean type, then returns false.
        /// </summary>
        public bool BoolOrDefault
        {
            get
            {
                if (isInputNullOrEmptyString) return false;

                try
                {
                    return System.Convert.ToBoolean(input.ToString());
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Converts the input a boolean int type.
        /// If input is null, empty string, any number or is not in an appropriate format for a boolean type, then returns null.
        /// </summary>
        public bool? BoolOrNull
        {
            get
            {
                if (isInputNullOrEmptyString) return null;

                try
                {
                    return System.Convert.ToBoolean(input.ToString());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts the input to an int type or throw exception.
        /// Throws an <see cref="FormatException" /> if input is null, empty string, not whole number or is not in an appropriate format for an int type.
        /// Throws an <see cref="OverflowException" /> if input is less than minValue or greater than MaxValue.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public int Int
        {
            get
            {
                if (isInputNullOrEmptyString) throw new FormatException();

                return System.Convert.ToInt32(input.ToString());
            }
        }

        /// <summary>
        /// Converts the input to an int type.
        /// If input is null, empty string, not whole number or is not in an appropriate format for an int type, then returns the default value of an int type.
        /// </summary>
        public int IntOrDefault
        {
            get
            {
                if (isInputNullOrEmptyString) return default;

                try
                {
                    return System.Convert.ToInt32(input.ToString());
                }
                catch (Exception)
                {
                    return default;
                }
            }
        }

        /// <summary>
        /// Converts the input to an int type.
        /// If input is null, empty string, not whole number or is not in an appropriate format for an int type, then returns null.
        /// </summary>
        public int? IntOrNull
        {
            get
            {
                if (isInputNullOrEmptyString) return null;

                try
                {
                    return System.Convert.ToInt32(input.ToString());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// Converts the input to a long type or throw exception.
        /// Throws an <see cref="FormatException" /> if input is null, empty string, not whole number or is not in an appropriate format for a long type.
        /// Throws an <see cref="OverflowException" /> if input is less than minValue or greater than MaxValue.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public long Long
        {
            get
            {
                if (isInputNullOrEmptyString) throw new FormatException();

                return System.Convert.ToInt64(input.ToString());
            }
        }

        /// <summary>
        /// Converts the input to a long type.
        /// If input is null, empty string, not whole number or is not in an appropriate format for a long type, then returns the default value of a long type.
        /// </summary>
        public long LongOrDefault
        {
            get
            {
                if (isInputNullOrEmptyString) return default;

                try
                {
                    return System.Convert.ToInt64(input.ToString());
                }
                catch (Exception)
                {
                    return default;
                }
            }
        }

        /// <summary>
        /// Converts the input to a long type.
        /// If input is null, empty string, not whole number or is not in an appropriate format for a long type, then it returns null.
        /// </summary>
        public long? LongOrNull
        {
            get
            {
                if (isInputNullOrEmptyString) return null;

                try
                {
                    return System.Convert.ToInt64(input.ToString());
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts the input to a decimal type or throw exception.
        /// Throws an <see cref="FormatException" /> if input is null, empty string, or is not in an appropriate format for a decimal type.
        /// Throws an <see cref="InvalidCastException" /> if conversion fails.
        /// Throws an <see cref="OverflowException" /> if input is less than minValue or greater than MaxValue.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="OverflowException"></exception>
        public decimal Decimal
        {
            get
            {
                if (isInputNullOrEmptyString) throw new FormatException();

                return System.Convert.ToDecimal(input);
            }
        }

        /// <summary>
        /// Converts the input to a decimal type.
        /// If input is null, empty string, or the conversion fails, then returns the default value of a decimal type.
        /// </summary>
        public decimal DecimalOrDefault
        {
            get
            {
                if (isInputNullOrEmptyString) return default;

                try
                {
                    return System.Convert.ToDecimal(input);
                }
                catch (Exception)
                {
                    return default;
                }
            }
        }

        /// <summary>
        /// Converts the input to a decimal type.
        /// If input is null, empty string, or the conversion fails, then it returns null.
        /// </summary>
        public decimal? DecimalOrNull
        {
            get
            {
                if (isInputNullOrEmptyString) return null;

                try
                {
                    return System.Convert.ToDecimal(input);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts the input to a double type or throw exception.
        /// Throws an <see cref="FormatException" /> if input is null, empty string, or is not in an appropriate format for a double type.
        /// Throws an <see cref="InvalidCastException" /> if conversion fails.
        /// Throws an <see cref="OverflowException" /> if input is less than minValue or greater than MaxValue.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        /// <exception cref="OverflowException"></exception>
        public double Double
        {
            get
            {
                if (isInputNullOrEmptyString) throw new FormatException();

                var output = System.Convert.ToDouble(input);

                if (double.IsInfinity(output)) throw new OverflowException();

                return output;
            }
        }

        /// <summary>
        /// Converts the input to a double type.
        /// If input is null, empty string, or the conversion fails, then returns the default value of a double type.
        /// </summary>
        public double DoubleOrDefault
        {
            get
            {
                if (isInputNullOrEmptyString) return default;

                try
                {
                    var output = System.Convert.ToDouble(input);

                    if (double.IsInfinity(output)) return default;

                    return output;
                }
                catch (Exception)
                {
                    return default;
                }
            }
        }

        /// <summary>
        /// Converts the input to a double type.
        /// If input is null, empty string, or the conversion fails, then it returns null.
        /// </summary>
        public double? DoubleOrNull
        {
            get
            {
                if (isInputNullOrEmptyString) return null;

                try
                {
                    var output = System.Convert.ToDouble(input);

                    if (double.IsInfinity(output)) return null;

                    return output;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        /// <summary>
        /// Converts the input to a DateTime type or throw exception.
        /// Throws an <see cref="FormatException" /> if input is null, empty string, or is not in an appropriate format for a DateTime type.
        /// Throws an <see cref="InvalidCastException" /> if conversion fails.
        /// </summary>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public DateTime DateTime
        {
            get
            {
                if (isInputNullOrEmptyString) throw new FormatException();

                return System.Convert.ToDateTime(input);
            }
        }

        /// <summary>
        /// Converts the input to a DateTime type.
        /// If input is null, empty string, or the conversion fails, then returns the default value of a DateTime type.
        /// </summary>
        public DateTime DateTimeOrDefault
        {
            get
            {
                if (isInputNullOrEmptyString) return default;

                try
                {
                    return System.Convert.ToDateTime(input);
                }
                catch (Exception)
                {
                    return default;
                }
            }
        }

        /// <summary>
        /// Converts the input to a DateTime type.
        /// If input is null, empty string, or the conversion fails, then it returns null.
        /// </summary>
        public DateTime? DateTimeOrNull
        {
            get
            {
                if (isInputNullOrEmptyString) return null;

                try
                {
                    return System.Convert.ToDateTime(input);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
