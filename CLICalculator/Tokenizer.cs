using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLICalculator
{
    public static class Tokenizer
    {
        public static List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            var number = new StringBuilder();

            foreach (var ch in expression)
            {
                if (char.IsDigit(ch) || ch == '.')
                {
                    number.Append(ch);
                }
                else if ("+-*/()".Contains(ch))
                {
                    if (number.Length > 0)
                    {
                        tokens.Add(number.ToString());
                        number.Clear();
                    }
                    tokens.Add(ch.ToString());
                }
                else if (char.IsLetter(ch))
                {
                    throw new FormatException($"Invalid character input: {ch}, letters are not allowed.");
                }
                else if (!char.IsWhiteSpace(ch))
                {
                    throw new FormatException($"Invalid operator: {ch}. Supported operators: +, -, *, /");
                }
            }

            if (number.Length > 0)
            {
                tokens.Add(number.ToString());
            }

            return tokens;
        }

    }
}
