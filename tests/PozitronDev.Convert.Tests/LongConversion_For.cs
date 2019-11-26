using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PozitronDev.Convert.Tests
{
    public class LongConversion_For
    {
        public static IEnumerable<object[]> LongPairs_ShouldPass =>
             new List<object[]>
             {
                        new object[] { long.MaxValue, long.MaxValue },
                        new object[] { 1L, 1 },
                        new object[] { 0L, 0 },
                        new object[] { -1L, -1 },
             };
        public static IEnumerable<object[]> LongInputs_ShouldFail =>
            LongInputs_ShouldThrowFormatException.Concat(LongInputs_ShouldThrowOverflowException);

        public static IEnumerable<object[]> LongInputs_ShouldThrowFormatException =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { string.Empty },
                new object[] { "NotEmptyString" },
                new object[] { "0.1" },
                new object[] { 0.1 },
                new object[] { DateTime.Now },
            };

        public static IEnumerable<object[]> LongInputs_ShouldThrowOverflowException =>
            new List<object[]>
            {
                new object[] { "7922816251426433759354395033500000" },
            };


        [Theory]
        [MemberData(nameof(LongPairs_ShouldPass))]
        public void ToLong_Should_Succeed(long expected, object input)
        {
            Assert.Equal(expected, input.To().Long);
            Assert.Equal(expected, input.To<long>());
        }

        [Theory]
        [MemberData(nameof(LongInputs_ShouldThrowFormatException))]
        public void ToLong_Should_ThrowFormatException(object input)
        {
            Assert.Throws<FormatException>(() => input.To().Long);
            Assert.Throws<FormatException>(() => input.To<long>());
        }

        [Theory]
        [MemberData(nameof(LongInputs_ShouldThrowOverflowException))]
        public void ToLong_Should_ThrowOverflowException(object input)
        {
            Assert.Throws<OverflowException>(() => input.To().Long);
            Assert.Throws<OverflowException>(() => input.To<long>());
        }

        [Theory]
        [MemberData(nameof(LongPairs_ShouldPass))]
        public void ToLongOrNull_Should_Succeed(long expected, object input)
        {
            Assert.Equal(expected, input.To().LongOrNull);
            Assert.Equal(expected, input.To<long?>());
        }
        [Theory]
        [MemberData(nameof(LongInputs_ShouldFail))]
        public void ToLongOrNull_Should_ReturnNull(object input)
        {
            Assert.Null(input.To().LongOrNull);
            Assert.Null(input.To<long?>());
        }

        [Theory]
        [MemberData(nameof(LongPairs_ShouldPass))]
        public void ToLongOrDefault_Should_Succeed(long expected, object input)
        {
            Assert.Equal(expected, input.To().LongOrDefault);
        }

        [Theory]
        [MemberData(nameof(LongInputs_ShouldFail))]
        public void ToLongOrDefault_Should_ReturnDefault(object input)
        {
            Assert.Equal(0m, input.To().LongOrDefault);
        }
    }
}
