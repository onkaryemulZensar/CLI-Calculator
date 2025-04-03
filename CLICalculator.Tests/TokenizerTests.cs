using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLICalculator;
using Xunit;

namespace CLICalculator.Tests
{
    public class TokenizerTests
    {
        [Theory]
        [InlineData("3 + 5", new[] { "3", "+", "5" })]
        [InlineData("10 / 2", new[] { "10", "/", "2" })]
        [InlineData("-2 + 3", new[] { "-2", "+", "3" })]
        [InlineData("2 - -3", new[] { "2", "-", "-3" })]
        [InlineData("3 - (+3)", new[] { "3", "-", "(", "+3", ")" })]
        [InlineData("+2 - 3", new[] { "+2", "-", "3"})]
        [InlineData("2 * (-1)", new[] { "2", "*", "(", "-1", ")" })]
        public void Tokenize_ValidInput_ReturnsExpectedTokens(string input, string[] expectedTokens)
        {
            var tokens = Tokenizer.Tokenize(input);
            Assert.Equal(expectedTokens, tokens);
        }

        [Theory]
        [InlineData("3 + a", "Invalid character input: a, letters are not allowed.")]
        [InlineData("3 + 5 & 2", "Invalid operator: &. Supported operators: +, -, *, /, ^, %")]
        public void Tokenize_InvalidInput_ThrowsFormatException(string input, string expectedMessage)
        {
            var exception = Assert.Throws<FormatException>(() => Tokenizer.Tokenize(input));
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
