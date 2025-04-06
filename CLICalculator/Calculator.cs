using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLICalculator
{
    public class Calculator
    {
        public static double Add(double a, double b)
        {
            double result = a + b;
            
            if (double.IsPositiveInfinity(result))
            {
                throw new OverflowException("Addition resulted in an overflow.");
            }

            if (double.IsNegativeInfinity(result))
            {
                throw new OverflowException("Addition resulted in an underflow.");
            }
            
            return result;
        }

        public static double Subtract(double a, double b)
        {
            double result = a - b;

            if (double.IsPositiveInfinity(result))
            {
                throw new OverflowException("Subtraction resulted in an overflow.");
            }

            if (double.IsNegativeInfinity(result))
            {
                throw new OverflowException("Subtraction resulted in an underflow.");
            }

            return result;
        }

        public static double Multiply(double a, double b)
        {
            double result = a * b;

            if (double.IsPositiveInfinity(result))
            {
                throw new OverflowException("Multiplication resulted in an overflow.");
            }
            
            if (double.IsNegativeInfinity(result))
            {
                throw new OverflowException("Multiplication resulted in an underflow.");
            }
            
            return result;
        }

        public static double Divide(double a, double b)
        {
            if(b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            double result = a / b;

            if (double.IsPositiveInfinity(result))
            {
                throw new OverflowException("Division resulted in an overflow.");
            }

            if (double.IsNegativeInfinity(result))
            {
                throw new OverflowException("Division resulted in an underflow.");
            }

            return result;
        }

        public static double Power(double a, double b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("0^0 is indeterminate.");
            }

            if (a < 0 && b % 1 != 0)
            {
                throw new ArgumentException("Negative base with fractional exponent results in a complex number.");
            }

            double result = Math.Pow(a, b);

            if (double.IsPositiveInfinity(result))
            {
                throw new OverflowException("Exponentiation resulted in an overflow.");
            }

            if (double.IsNegativeInfinity(result))
            {
                throw new OverflowException("Exponentiation resulted in an underflow.");
            }
            
            return result;
        }

        public static double Percentage(double a, double b)
        {
            double result = a * (b / 100);

            if (double.IsPositiveInfinity(result))
            {
                throw new OverflowException("Percentage calculation resulted in an overflow.");
            }

            if (double.IsNegativeInfinity(result))
            {
                throw new OverflowException("Percentage calculation resulted in an underflow.");
            }

            return result;
        }
    } 

}
