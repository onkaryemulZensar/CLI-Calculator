using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLICalculator;
using Xunit;

namespace CLICalculator.Tests
{
    public class InfixToPostfixConverterTests
    {
        [Theory]
        [InlineData(new[] { "3", "+", "5" }, new[] { "3", "5", "+" })]
        [InlineData(new[] { "10", "/", "2" }, new[] { "10", "2", "/" })]
        [InlineData(new[] { "3.5", "*", "2" }, new[] { "3.5", "2", "*" })]
        [InlineData(new[] { "3", "-", "5", "*", "4", "/", "2" }, new[] { "3", "5", "4", "*", "2", "/", "-" })]
        public void InfixToPostfix_ValidInput_ReturnsExpectedPostfix(string[] input, string[] expectedPostfix)
        {
            var postfix = InfixToPostfixConverter.InfixToPostfix(new List<string>(input));
            Assert.Equal(expectedPostfix, postfix);
        }
    }
}
