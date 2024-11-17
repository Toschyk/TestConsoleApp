using NUnit.Framework;

namespace TestConsoleApp.Tests
{
    public class CalculatorTests
    {
        // Тестируем функциональность калькулятора с различными операциями
        [TestCase(10, 5, '+', 15)] // Сложение
        [TestCase(10, 5, '-', 5)]  // Вычитание
        [TestCase(10, 5, '*', 50)] // Умножение
        [TestCase(10, 5, '/', 2)]  // Деление
        public void TestCalculator(double num1, double num2, char operation, double expected)
        {
            // Вызываем метод Calculate и сравниваем результат с ожидаемым
            double result = Calculator.Calculate(num1, num2, operation);
            Assert.AreEqual(expected, result, "Результат операции не соответствует ожидаемому.");
        }

        // Тестируем деление на ноль
        [Test]
        public void TestDivisionByZero()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Calculate(10, 0, '/'), "Ожидается исключение при делении на ноль.");
        }
    }

    // Класс для реализации логики калькулятора (вынесен для удобства тестирования)
    public static class Calculator
    {
        /// <summary>
        /// Выполняет арифметическую операцию над двумя числами.
        /// </summary>
        /// <param name="num1">Первое число</param>
        /// <param name="num2">Второе число</param>
        /// <param name="operation">Операция (+, -, *, /)</param>
        /// <returns>Результат операции</returns>
        public static double Calculate(double num1, double num2, char operation)
        {
            return operation switch
            {
                '+' => num1 + num2, // Сложение
                '-' => num1 - num2, // Вычитание
                '*' => num1 * num2, // Умножение
                '/' => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(), // Деление
                _ => throw new InvalidOperationException("Некорректная операция") // Некорректный ввод
            };
        }
    }
}
