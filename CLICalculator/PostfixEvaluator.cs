using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLICalculator
{
    public static class PostfixEvaluator
    {
        public static double EvaluatePostfix(List<string> postfix)
        {
            var stack = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token, out var number))
                {
                    stack.Push(number);
                }
                else
                {
                    if (stack.Count < 2)
                    {
                        throw new FormatException("Invalid expression. Please check the input.");
                    }

                    var num2 = stack.Pop();
                    var num1 = stack.Pop();

                    stack.Push(token switch
                    {
                        "+" => Calculator.Add(num1, num2),
                        "-" => Calculator.Subtract(num1, num2),
                        "*" => Calculator.Multiply(num1, num2),
                        "/" => Calculator.Divide(num1, num2),
                        _ => throw new FormatException($"Invalid operator: {token}. Supported operators: +, -, *, /")
                    });
                }
            }

            if (stack.Count != 1)
            {
                throw new FormatException("Invalid expression. Please check the input.");
            }

            return stack.Pop();
        }
    }
}
