namespace Tests
{
    public class IntConversion_For
    {
        public static IEnumerable<object[]> IntPairs_ShouldPass =>
             new List<object[]>
             {
                        new object[] { int.MaxValue, int.MaxValue },
                        new object[] { 1, 1 },
                        new object[] { 0, 0 },
                        new object[] { -1, -1 },
             };
        public static IEnumerable<object[]> IntInputs_ShouldFail =>
            IntInputs_ShouldThrowFormatException.Concat(IntInputs_ShouldThrowOverflowException);

        public static IEnumerable<object[]> IntInputs_ShouldThrowFormatException =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { string.Empty },
                new object[] { "NotEmptyString" },
                new object[] { "0.1" },
                new object[] { 0.1 },
                new object[] { DateTime.Now },
            };

        public static IEnumerable<object[]> IntInputs_ShouldThrowOverflowException =>
            new List<object[]>
            {
                new object[] { "7922816251426433759354395033500000" },
            };


        [Theory]
        [MemberData(nameof(IntPairs_ShouldPass))]
        public void ToInt_Should_Succeed(int expected, object input)
        {
            Assert.Equal(expected, input.To().Int);
            Assert.Equal(expected, input.To<int>());
        }

        [Theory]
        [MemberData(nameof(IntInputs_ShouldThrowFormatException))]
        public void ToInt_Should_ThrowFormatException(object input)
        {
            Assert.Throws<FormatException>(() => input.To().Int);
            Assert.Throws<FormatException>(() => input.To<int>());
        }


        [Theory]
        [MemberData(nameof(IntInputs_ShouldThrowOverflowException))]
        public void ToInt_Should_ThrowOverflowException(object input)
        {
            Assert.Throws<OverflowException>(() => input.To().Int);
            Assert.Throws<OverflowException>(() => input.To<int>());
        }

        [Theory]
        [MemberData(nameof(IntPairs_ShouldPass))]
        public void ToIntOrNull_Should_Succeed(int expected, object input)
        {
            Assert.Equal(expected, input.To().IntOrNull);
            Assert.Equal(expected, input.To<int?>());
        }
        [Theory]
        [MemberData(nameof(IntInputs_ShouldFail))]
        public void ToIntOrNull_Should_ReturnNull(object input)
        {
            Assert.Null(input.To().IntOrNull);
            Assert.Null(input.To<int?>());
        }

        [Theory]
        [MemberData(nameof(IntPairs_ShouldPass))]
        public void ToIntOrDefault_Should_Succeed(int expected, object input)
        {
            Assert.Equal(expected, input.To().IntOrDefault);
        }

        [Theory]
        [MemberData(nameof(IntInputs_ShouldFail))]
        public void ToIntOrDefault_Should_ReturnDefault(object input)
        {
            Assert.Equal(0m, input.To().IntOrDefault);
        }
    }
}
