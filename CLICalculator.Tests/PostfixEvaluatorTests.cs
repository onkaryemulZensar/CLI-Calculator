using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CLICalculator.Tests
{
    public class PostfixEvaluatorTests
    {
        [Theory]
        [InlineData(new[] { "3", "5", "+" }, 8)]
        [InlineData(new[] { "10", "2", "/" }, 5)]
        [InlineData(new[] { "3.5", "2", "*" }, 7)]
        [InlineData(new[] { "3", "5", "4", "*", "2", "/", "-" }, -7)]
        public void EvaluatePostfix_ValidInput_ReturnsExpectedResult(string[] input, double expectedResult)
        {
            var result = PostfixEvaluator.EvaluatePostfix(new List<string>(input));
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new[] { "3", "+" }, "Invalid expression. Please check the input.")]
        [InlineData(new[] { "3", "5", "^" }, "Invalid operator: ^. Supported operators: +, -, *, /")]
        public void EvaluatePostfix_InvalidInput_ThrowsFormatException(string[] input, string expectedMessage)
        {
            var exception = Assert.Throws<FormatException>(() => PostfixEvaluator.EvaluatePostfix(new List<string>(input)));
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
