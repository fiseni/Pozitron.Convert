namespace Tests
{
    public class BoolConversion_For
    {
        public static IEnumerable<object[]> BoolPairs_ShouldPass =>
            new List<object[]>
            {
                new object[] { true, true },
                new object[] { true, "true" },
                new object[] { true, "True" },
                new object[] { true, "TRUE" },
                new object[] { true, "tRue" },
                new object[] { false, false },
                new object[] { false, "false" },
                new object[] { false, "False" },
                new object[] { false, "FALSE" },
                new object[] { false, "faLse" },
            };

        public static IEnumerable<object[]> BoolInputs_ShouldFail =>
            BoolInputs_ShouldThrowFormatException;


        public static IEnumerable<object[]> BoolInputs_ShouldThrowFormatException =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { string.Empty },
                new object[] { "NotEmptyString" },
                new object[]  { 0 },
                new object[]  { 1 },
                new object[]  { double.MaxValue },
                new object[]  { DateTime.Now },
            };


        [Theory]
        [MemberData(nameof(BoolPairs_ShouldPass))]
        public void ToBool_Should_Succeed(bool expected, object input)
        {
            Assert.Equal(expected, input.To().Bool);
            Assert.Equal(expected, input.To<bool>());
        }

        [Theory]
        [MemberData(nameof(BoolInputs_ShouldThrowFormatException))]
        public void ToBool_Should_ThrowFormatException(object input)
        {
            Assert.Throws<FormatException>(() => input.To().Bool);
            Assert.Throws<FormatException>(() => input.To<bool>());
        }


        [Theory]
        [MemberData(nameof(BoolPairs_ShouldPass))]
        public void ToBoolOrNull_Should_Succeed(bool expected, object input)
        {
            Assert.Equal(expected, input.To().BoolOrNull);
            Assert.Equal(expected, input.To<bool?>());
        }
        [Theory]
        [MemberData(nameof(BoolInputs_ShouldFail))]
        public void ToBoolOrNull_Should_ReturnNull(object input)
        {
            Assert.Null(input.To().BoolOrNull);
            Assert.Null(input.To<bool?>());
        }

        [Theory]
        [MemberData(nameof(BoolPairs_ShouldPass))]
        public void ToBoolOrDefault_Should_Succeed(bool expected, object input)
        {
            Assert.Equal(expected, input.To().BoolOrDefault);
        }

        [Theory]
        [MemberData(nameof(BoolInputs_ShouldFail))]
        public void ToBoolOrDefault_Should_ReturnDefault(object input)
        {
            Assert.False(input.To().BoolOrDefault);
        }
    }
}
