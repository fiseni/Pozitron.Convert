using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PozitronDev.Convert.Tests
{
    public class DateTimeConversion_For
    {
        public static IEnumerable<object[]> DateTimePairs_ShouldPass =>
            new List<object[]>
            {
                new object[] { DateTime.MaxValue, DateTime.MaxValue },
                new object[] { new DateTime(2019,11,26), "2019-11-26T00:00:00" },
            };

        public static IEnumerable<object[]> DateTimeInputs_ShouldFail =>
            DateTimeInputs_ShouldThrowFormatException.Concat(DateTimeInputs_ShouldThrowInvalidCastException);


        public static IEnumerable<object[]> DateTimeInputs_ShouldThrowFormatException =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { string.Empty },
                new object[] { "NotEmptyString" },
            };

        public static IEnumerable<object[]> DateTimeInputs_ShouldThrowInvalidCastException =>
            new List<object[]>
            {
                new object[]  { 0 },
                new object[]  { int.MaxValue },
                new object[]  { double.MaxValue },
            };


        [Theory]
        [MemberData(nameof(DateTimePairs_ShouldPass))]
        public void ToDateTime_Should_Succeed(DateTime expected, object input)
        {
            Assert.Equal(expected, input.To().DateTime);
            Assert.Equal(expected, input.To<DateTime>());
        }

        [Theory]
        [MemberData(nameof(DateTimeInputs_ShouldThrowFormatException))]
        public void ToDateTime_Should_ThrowFormatException(object input)
        {
            Assert.Throws<FormatException>(() => input.To().DateTime);
            Assert.Throws<FormatException>(() => input.To<DateTime>());
        }

        [Theory]
        [MemberData(nameof(DateTimeInputs_ShouldThrowInvalidCastException))]
        public void ToDateTime_Should_ThrowInvalidCastException(object input)
        {
            Assert.Throws<InvalidCastException>(() => input.To().DateTime);
            Assert.Throws<InvalidCastException>(() => input.To<DateTime>());
        }

        [Theory]
        [MemberData(nameof(DateTimePairs_ShouldPass))]
        public void ToDateTimeOrNull_Should_Succeed(DateTime expected, object input)
        {
            Assert.Equal(expected, input.To().DateTimeOrNull);
            Assert.Equal(expected, input.To<DateTime?>());
        }
        [Theory]
        [MemberData(nameof(DateTimeInputs_ShouldFail))]
        public void ToDateTimeOrNull_Should_ReturnNull(object input)
        {
            Assert.Null(input.To().DateTimeOrNull);
            Assert.Null(input.To<DateTime?>());
        }

        [Theory]
        [MemberData(nameof(DateTimePairs_ShouldPass))]
        public void ToDateTimeOrDefault_Should_Succeed(DateTime expected, object input)
        {
            Assert.Equal(expected, input.To().DateTimeOrDefault);
        }

        [Theory]
        [MemberData(nameof(DateTimeInputs_ShouldFail))]
        public void ToDateTimeOrDefault_Should_ReturnDefault(object input)
        {
            Assert.Equal(default(DateTime), input.To().DateTimeOrDefault);
        }
    }
}
