using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLICalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunCalculator(false);
        }

        public static void RunCalculator(bool isTest = false)
        {
            bool exit = false;

            while (!exit)
            {
                if (!isTest)
                {
                    Console.Clear();
                }

                Console.WriteLine("******************* CLI Calculator ******************");
                Console.WriteLine("Enter a mathematical expression to calculate or type 'exit' to quit:");

                try
                {
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                    {
                        Console.WriteLine("Exiting CLI Calculator program.....!");
                        break;
                    }

                    double result = EvaluateExpression(input);
                    Console.WriteLine($"Result : {result}");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Please enter a valid mathematical expression : {fe.Message}");
                }
                catch (DivideByZeroException dze)
                {
                    Console.WriteLine($"Error : {dze.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error : {e.Message}");
                }

                Console.WriteLine("\nPress any key to continue...");
                if (!isTest)
                {
                    Console.ReadKey();
                }

                if (isTest)
                {
                    exit = true;
                }
            }
        }

        public static double EvaluateExpression(string expression)
        {
            try
            {
                var tokens = Tokenizer.Tokenize(expression);
                var postfix = InfixToPostfixConverter.InfixToPostfix(tokens);
                return PostfixEvaluator.EvaluatePostfix(postfix);
            }
            catch (FormatException fe)
            {
                throw new FormatException(fe.Message);
            }
        }
    }
}

