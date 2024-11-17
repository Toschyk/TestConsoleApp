using NUnit.Framework;

namespace TestConsoleApp.Tests
{
    public class CalculatorTests
    {
        [TestCase(10, 5, '+', 15)]
        [TestCase(10, 5, '-', 5)]
        [TestCase(10, 5, '*', 50)]
        [TestCase(10, 5, '/', 2)]
        public void TestCalculator(double num1, double num2, char operation, double expected)
        {
            double result = Calculator.Calculate(num1, num2, operation);
            Assert.AreEqual(expected, result);
        }
    }

    public static class Calculator
    {
        public static double Calculate(double num1, double num2, char operation)
        {
            return operation switch
            {
                '+' => num1 + num2,
                '-' => num1 - num2,
                '*' => num1 * num2,
                '/' => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(),
                _ => throw new InvalidOperationException("Invalid operation")
            };
        }
    }
}
