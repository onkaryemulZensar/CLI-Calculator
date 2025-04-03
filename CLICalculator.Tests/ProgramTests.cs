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
        [InlineData("-2 + 3\nexit\n", "Result : 1")]
        [InlineData("2 - -3\nexit\n", "Result : 5")]
        [InlineData("+2 - 3\nexit\n", "Result : -1")]
        [InlineData("3 - (+3)\nexit\n", "Result : 0")]
        [InlineData("2 * (-1)\nexit\n", "Result : -2")]
        [InlineData("2 * (+3)\nexit\n", "Result : 6")]
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
        [InlineData("3 & 5\nexit\n", "Please enter a valid mathematical expression : Invalid operator: &. Supported operators: +, -, *, /, ^, %")]
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

