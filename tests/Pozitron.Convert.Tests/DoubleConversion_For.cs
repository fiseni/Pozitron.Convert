namespace Tests
{
    public class DoubleConversion_For
    {
        public static IEnumerable<object[]> DoublePairs_ShouldPass =>
            new List<object[]>
            {
                new object[] { double.MaxValue, double.MaxValue },
                new object[] { float.MaxValue, float.MaxValue },
                new object[] { 79228162514264337593543950335d, decimal.MaxValue },
                new object[] { 1d, 1 },
                new object[] { 0d, 0 },
                new object[] { -1d, -1 },
                new object[] { 0.1d, 0.1 },
                new object[] { 0.1d, "0.1" },
            };

        public static IEnumerable<object[]> DoubleInputs_ShouldFail =>
            DoubleInputs_ShouldThrowFormatException.Concat(DoubleInputs_ShouldThrowInvalidCastException)
                                                    .Concat(DoubleInputs_ShouldThrowOverflowException);

        public static IEnumerable<object[]> DoubleInputs_ShouldThrowFormatException =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { string.Empty },
                new object[] { "NotEmptyString" },
            };

        public static IEnumerable<object[]> DoubleInputs_ShouldThrowInvalidCastException =>
            new List<object[]>
            {
                new object[]  { DateTime.Now },
            };

        public static IEnumerable<object[]> DoubleInputs_ShouldThrowOverflowException =>
            new List<object[]>
            {
                new object[] { "1.79769313486232E+999" },
            };


        [Theory]
        [MemberData(nameof(DoublePairs_ShouldPass))]
        public void ToDouble_Should_Succeed(double expected, object input)
        {
            Assert.Equal(expected, input.To().Double);
            Assert.Equal(expected, input.To<double>());
        }

        [Theory]
        [MemberData(nameof(DoubleInputs_ShouldThrowFormatException))]
        public void ToDouble_Should_ThrowFormatException(object input)
        {
            Assert.Throws<FormatException>(() => input.To().Double);
            Assert.Throws<FormatException>(() => input.To<double>());
        }

        [Theory]
        [MemberData(nameof(DoubleInputs_ShouldThrowInvalidCastException))]
        public void ToDouble_Should_ThrowInvalidCastException(object input)
        {
            Assert.Throws<InvalidCastException>(() => input.To().Double);
            Assert.Throws<InvalidCastException>(() => input.To<double>());
        }

        [Theory]
        [MemberData(nameof(DoubleInputs_ShouldThrowOverflowException))]
        public void ToDouble_Should_ThrowOverflowException(object input)
        {
            Assert.Throws<OverflowException>(() => input.To().Double);
            Assert.Throws<OverflowException>(() => input.To<double>());
        }

        [Theory]
        [MemberData(nameof(DoublePairs_ShouldPass))]
        public void ToDoubleOrNull_Should_Succeed(double expected, object input)
        {
            Assert.Equal(expected, input.To().DoubleOrNull);
            Assert.Equal(expected, input.To<double?>());
        }
        [Theory]
        [MemberData(nameof(DoubleInputs_ShouldFail))]
        public void ToDoubleOrNull_Should_ReturnNull(object input)
        {
            Assert.Null(input.To().DoubleOrNull);
            Assert.Null(input.To<double?>());
        }

        [Theory]
        [MemberData(nameof(DoublePairs_ShouldPass))]
        public void ToDoubleOrDefault_Should_Succeed(double expected, object input)
        {
            Assert.Equal(expected, input.To().DoubleOrDefault);
        }

        [Theory]
        [MemberData(nameof(DoubleInputs_ShouldFail))]
        public void ToDoubleOrDefault_Should_ReturnDefault(object input)
        {
            Assert.Equal(0d, input.To().DoubleOrDefault);
        }
    }
}
