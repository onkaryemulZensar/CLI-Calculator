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
        public void Add_ReturnsSum(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Add(a, b));
        }

        // Overflow and underflow tests 
        [Theory]
        [InlineData(double.MaxValue, double.MaxValue)]
        [InlineData(double.MinValue, double.MinValue)]
        public void Add_Overflow_ThrowsOverflowException(double a, double b)
        {
            Assert.Throws<OverflowException>(() => Calculator.Add(a, b));
        }

        // Subtraction tests
        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-3, -5, 2)]
        public void Subtract_ReturnsDifference(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Subtract(a, b));
        }

        [Theory]
        [InlineData(double.MaxValue, -double.MaxValue)]
        [InlineData(double.MinValue, double.MaxValue)]
        public void Subtract_Overflow_ThrowsOverflowException(double a, double b)
        {
            Assert.Throws<OverflowException>(() => Calculator.Subtract(a, b));
        }

        // Multiplication tests
        [Theory]
        [InlineData(-3, -5, 15)]
        [InlineData(3, -5, -15)]
        public void Multiply_ReturnsProduct(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Multiply(a, b));
        }

        [Theory]
        [InlineData(double.MaxValue, 2)]
        [InlineData(double.MinValue, 2)]
        public void Multiply_Overflow_ThrowsOverflowException(double a, double b)
        {
            Assert.Throws<OverflowException>(() => Calculator.Multiply(a, b));
        }


        // Division tests
        [Theory]
        [InlineData(-10, -5, 2)]
        [InlineData(10, -5, -2)]
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

        [Theory]
        [InlineData(double.MaxValue, 0.5)]
        [InlineData(double.MinValue, 0.5)]
        public void Divide_Overflow_ThrowsOverflowException(double a, double b)
        {
            Assert.Throws<OverflowException>(() => Calculator.Divide(a, b));
        }

        // Power tests
        [Theory]
        [InlineData(2, -2, 0.25)]
        [InlineData(-2, 3, -8)]
        public void Power_ReturnsExponentiation(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Power(a, b));
        }

        [Theory]
        [InlineData(0, 0)]
        public void Power_ZeroToZero_ThrowsArgumentException(double a, double b)
        {
            Assert.Throws<ArgumentException>(() => Calculator.Power(a, b));
        }

        [Theory]
        [InlineData(-2, 0.5)]
        public void Power_NegativeBaseWithFractionalExponent_ThrowsArgumentException(double a, double b)
        {
            Assert.Throws<ArgumentException>(() => Calculator.Power(a, b));
        }


        [Theory]
        [InlineData(double.MaxValue, 2)]
        [InlineData(double.MinValue, 2)]
        public void Power_Overflow_ThrowsOverflowException(double a, double b)
        {
            Assert.Throws<OverflowException>(() => Calculator.Power(a, b));
        }

        // Percentage tests
        [Theory]
        [InlineData(200, 50, 100)]
        [InlineData(50, 20, 10)]
        public void Percentage_ReturnsPercentage(double a, double b, double expected)
        {
            Assert.Equal(expected, Calculator.Percentage(a, b));
        }

        [Theory]
        [InlineData(double.MaxValue, 200)]
        [InlineData(double.MinValue, 200)]
        public void Percentage_Overflow_ThrowsOverflowException(double a, double b)
        {
            Assert.Throws<OverflowException>(() => Calculator.Percentage(a, b));
        }
    }
}

