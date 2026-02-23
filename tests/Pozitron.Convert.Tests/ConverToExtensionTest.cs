using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pozitron.Convert.Tests
{
    public class ConverToExtensionTest
    {
        [Fact]
        public void ToDateTime_Should_ThrowFormatException()
        {
            var input = new object();
            Assert.Throws<InvalidCastException>(() => input.To<ConvertTo>());
        }
    }
}
