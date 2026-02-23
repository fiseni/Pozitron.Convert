using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Pozitron.Convert.Tests
{
    public class StringConversion_For
    {
        public static IEnumerable<object[]> StringPairs_ShouldPass =>
             new List<object[]>
             {
                new object[] { "1", 1 },
                new object[] { "0.1", 0.1d },
                new object[] { "79228162514264337593543950335", decimal.MaxValue },
                new object[] { "SomeStringValue", "SomeStringValue" },
             };

        public static IEnumerable<object[]> StringInputs_ShouldFail =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { string.Empty },
            };


        [Theory]
        [MemberData(nameof(StringPairs_ShouldPass))]
        public void ToStringOrEmpty_Should_Succeed(string expected, object input)
        {
            Assert.Equal(expected, input.To().StringOrEmpty);
        }

        [Theory]
        [MemberData(nameof(StringInputs_ShouldFail))]
        public void ToStringOrEmpty_Should_ReturnEmpty(object input)
        {
            Assert.Equal(string.Empty, input.To().StringOrEmpty);
        }

        [Theory]
        [MemberData(nameof(StringPairs_ShouldPass))]
        public void ToStringOrNull_Should_Succeed(string expected, object input)
        {
            Assert.Equal(expected, input.To().StringOrNull);
        }

        [Theory]
        [MemberData(nameof(StringInputs_ShouldFail))]
        public void ToStringOrNull_Should_ReturnNull(object input)
        {
            Assert.Null(input.To().StringOrNull);
        }
    }
}
