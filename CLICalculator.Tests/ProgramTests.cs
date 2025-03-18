using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CLICalculator;
using Xunit;

namespace CLICalculator.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("3 + 5\nexit\n", "Result : 8")]
        [InlineData("5 - 3\nexit\n", "Result : 2")]
        [InlineData("3 * 5\nexit\n", "Result : 15")]
        [InlineData("10 / 5\nexit\n", "Result : 2")]
        [InlineData("10 / 0\nexit\n", "Error : Cannot divide by zero.")]
        [InlineData("3 - 5 * 4 / 2\nexit\n", "Result : -7")]
        [InlineData("exit\n", "Exiting CLI Calculator program.....!")]
        public void RunCalculator_ValidInput_ReturnsExpectedOutput(string input, string expectedOutput)
        {
            var inputReader = new StringReader(input);
            var outputWriter = new StringWriter();

            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            Program.RunCalculator(true);

            var output = outputWriter.ToString();
            Assert.Contains(expectedOutput, output);
        }


        [Theory]
        [InlineData("a + 5\nexit\n", "Please enter a valid mathematical expression : Invalid character input: a, letters are not allowed.")]
        [InlineData("3 + 5 *\nexit\n", "Please enter a valid mathematical expression : Invalid expression. Please check the input.")]
        [InlineData("3 ^ 5\nexit\n", "Please enter a valid mathematical expression : Invalid operator: ^. Supported operators: +, -, *, /")]
        public void RunCalculator_InvalidInput_ShowsErrorMessage(string input, string expectedOutput)
        {
            var inputReader = new StringReader(input);
            var outputWriter = new StringWriter();

            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            Program.RunCalculator(true);

            var output = outputWriter.ToString();
            Assert.Contains(expectedOutput, output);
        }
    }

}

