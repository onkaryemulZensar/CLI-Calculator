using System;
using System.Threading.Tasks;
using Xunit;
using CLICalculator;

namespace CLICalculator.Tests
{
    public class CalculatorTests
    {
        // Addition tests
        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(-3, -5, -8)]
        [InlineData(5, -3, 2)]
        [InlineData(0, 5, 5)]
        public void Add_ReturnsSum(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Add(a, b));
        }

        // Subtraction tests
        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-3, -5, 2)]
        [InlineData(5, -3, 8)]
        [InlineData(0, 5, -5)]
        public void Subtract_ReturnsDifference(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Subtract(a, b));
        }

        // Multiplication tests
        [Theory]
        [InlineData(3, 5, 15)]
        [InlineData(-3, -5, 15)]
        [InlineData(3, -5, -15)]
        [InlineData(3, 0, 0)]
        public void Multiply_ReturnsProduct(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Multiply(a, b));
        }

        // Division tests
        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(-10, -5, 2)]
        [InlineData(10, -5, -2)]
        [InlineData(10, 1, 10)]
        public void Divide_ReturnsQuotient(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Divide(a, b));
        }

        [Theory]
        [InlineData(10, 0)]
        public void Divide_ByZero_ThrowsDivideByZeroException(double a, double b)
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Divide(a, b));
        }
    }
}

