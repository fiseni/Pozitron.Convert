namespace Tests
{
    public class DecimalConversion_For
    {
        public static IEnumerable<object[]> DecimalPairs_ShouldPass =>
             new List<object[]>
             {
                        new object[] { decimal.MaxValue, decimal.MaxValue },
                        new object[] { 1m, 1 },
                        new object[] { 0m, 0 },
                        new object[] { -1m, -1 },
                        new object[] { 0.1m, 0.1 },
                        new object[] { 0.1m, "0.1" },
             };
        public static IEnumerable<object[]> DecimalInputs_ShouldFail =>
            DecimalInputs_ShouldThrowFormatException.Concat(DecimalInputs_ShouldThrowInvalidCastException)
                                                    .Concat(DecimalInputs_ShouldThrowOverflowException);

        public static IEnumerable<object[]> DecimalInputs_ShouldThrowFormatException =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { string.Empty },
                new object[] { "NotEmptyString" },
            };

        public static IEnumerable<object[]> DecimalInputs_ShouldThrowInvalidCastException =>
            new List<object[]>
            {
                new object[]  { DateTime.Now },
            };

        public static IEnumerable<object[]> DecimalInputs_ShouldThrowOverflowException =>
            new List<object[]>
            {
                new object[] { "7922816251426433759354395033500000" },
            };


        [Theory]
        [MemberData(nameof(DecimalPairs_ShouldPass))]
        public void ToDecimal_Should_Succeed(decimal expected, object input)
        {
            Assert.Equal(expected, input.To().Decimal);
            Assert.Equal(expected, input.To<decimal>());
        }

        [Theory]
        [MemberData(nameof(DecimalInputs_ShouldThrowFormatException))]
        public void ToDecimal_Should_ThrowFormatException(object input)
        {
            Assert.Throws<FormatException>(() => input.To().Decimal);
            Assert.Throws<FormatException>(() => input.To<decimal>());
        }

        [Theory]
        [MemberData(nameof(DecimalInputs_ShouldThrowInvalidCastException))]
        public void ToDecimal_Should_ThrowInvalidCastException(object input)
        {
            Assert.Throws<InvalidCastException>(() => input.To().Decimal);
            Assert.Throws<InvalidCastException>(() => input.To<decimal>());
        }

        [Theory]
        [MemberData(nameof(DecimalInputs_ShouldThrowOverflowException))]
        public void ToDecimal_Should_ThrowOverflowException(object input)
        {
            Assert.Throws<OverflowException>(() => input.To().Decimal);
            Assert.Throws<OverflowException>(() => input.To<decimal>());
        }

        [Theory]
        [MemberData(nameof(DecimalPairs_ShouldPass))]
        public void ToDecimalOrNull_Should_Succeed(decimal expected, object input)
        {
            Assert.Equal(expected, input.To().DecimalOrNull);
            Assert.Equal(expected, input.To<decimal?>());
        }
        [Theory]
        [MemberData(nameof(DecimalInputs_ShouldFail))]
        public void ToDecimalOrNull_Should_ReturnNull(object input)
        {
            Assert.Null(input.To().DecimalOrNull);
            Assert.Null(input.To<decimal?>());
        }

        [Theory]
        [MemberData(nameof(DecimalPairs_ShouldPass))]
        public void ToDecimalOrDefault_Should_Succeed(decimal expected, object input)
        {
            Assert.Equal(expected, input.To().DecimalOrDefault);
        }

        [Theory]
        [MemberData(nameof(DecimalInputs_ShouldFail))]
        public void ToDecimalOrDefault_Should_ReturnDefault(object input)
        {
            Assert.Equal(0m, input.To().DecimalOrDefault);
        }
    }
}
