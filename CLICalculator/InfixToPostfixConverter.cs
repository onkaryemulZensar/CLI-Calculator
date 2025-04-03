using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLICalculator
{
    public static class InfixToPostfixConverter
    {
        private static readonly Dictionary<string, int> precedence = new Dictionary<string, int> {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "^", 3 },
            { "%", 4 },
            { "(", 0 }
        };

        private static readonly Dictionary<string, bool> rightAssociative = new Dictionary<string, bool> {
              { "^", true }
        };

        public static List<string> InfixToPostfix(List<string> infixTokens)
        {
            var postfix = new List<string>();
            var operatorsStack = new Stack<string>();

            foreach (var token in infixTokens)
            {
                if (double.TryParse(token, out _))
                {
                    postfix.Add(token);
                }
                else if (token == "(")
                {
                    operatorsStack.Push(token);
                }
                else if (token == ")")
                {
                    while (operatorsStack.Peek() != "(")
                    {
                        postfix.Add(operatorsStack.Pop());
                    }
                    operatorsStack.Pop();
                }
                else
                {
                    while (operatorsStack.Count > 0 && precedence.ContainsKey(operatorsStack.Peek()) &&
                       ((rightAssociative.ContainsKey(token) && rightAssociative[token] && precedence[token] < precedence[operatorsStack.Peek()]) ||
                        (!rightAssociative.ContainsKey(token) && precedence[token] <= precedence[operatorsStack.Peek()])))
                    {
                        postfix.Add(operatorsStack.Pop());
                    }
                    operatorsStack.Push(token);
                }
            }

            while (operatorsStack.Count > 0)
            {
                postfix.Add(operatorsStack.Pop());
            }

            return postfix;
        }
    }
}
