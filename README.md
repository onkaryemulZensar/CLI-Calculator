# CLI-Calculator

A simple CLI calculator implemented in C# that supports basic and advanced arithmetic operations. This project includes unit tests and follows best practices in software development, such as clean code principles, unit testing, and version control with Git.

## Features

- **Basic Arithmetic Operations**: Addition, subtraction, multiplication, and division.
- **Advanced Operations**: Exponentiation (`^`) and percentage (`%`).
- **Unary Operators**: Handles unary `+` and `-` operators.
- **Parentheses**: Supports expressions with parentheses to enforce operation precedence.
- **Error Handling**: Detects and reports invalid characters, unsupported operators, and divide-by-zero errors.

## Components

1. **Tokenizer**: Converts input expressions into tokens, handling numbers, operators, and parentheses.
2. **InfixToPostfixConverter**: Converts infix expressions to postfix notation, handling operator precedence and associativity.
3. **PostfixEvaluator**: Evaluates postfix expressions, handling all supported operators and unary operations.
4. **Calculator**: Provides methods for basic and advanced arithmetic operations, including overflow and underflow checks.

## Unit Tests

This project uses [xUnit](https://xunit.net/) for unit testing. The unit tests cover valid and invalid input scenarios, including edge cases for overflow, underflow, and divide-by-zero errors.

### Test Coverage

- **TokenizerTests**: Tests for tokenizing valid and invalid input expressions, including handling of unary operators.
- **InfixToPostfixConverterTests**: Tests for converting infix expressions to postfix notation, ensuring correct operator precedence and associativity.
- **PostfixEvaluatorTests**: Tests for evaluating postfix expressions, including handling of unary operators and error conditions.
- **CalculatorTests**: Tests for individual arithmetic operations, including overflow and underflow checks.
