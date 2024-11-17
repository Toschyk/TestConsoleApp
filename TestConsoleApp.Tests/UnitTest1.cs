using NUnit.Framework;

namespace TestConsoleApp.Tests
{
    public class CalculatorTests
    {
        // ��������� ���������������� ������������ � ���������� ����������
        [TestCase(10, 5, '+', 15)] // ��������
        [TestCase(10, 5, '-', 5)]  // ���������
        [TestCase(10, 5, '*', 50)] // ���������
        [TestCase(10, 5, '/', 2)]  // �������
        public void TestCalculator(double num1, double num2, char operation, double expected)
        {
            // �������� ����� Calculate � ���������� ��������� � ���������
            double result = Calculator.Calculate(num1, num2, operation);
            Assert.AreEqual(expected, result, "��������� �������� �� ������������� ����������.");
        }

        // ��������� ������� �� ����
        [Test]
        public void TestDivisionByZero()
        {
            Assert.Throws<DivideByZeroException>(() => Calculator.Calculate(10, 0, '/'), "��������� ���������� ��� ������� �� ����.");
        }
    }

    // ����� ��� ���������� ������ ������������ (������� ��� �������� ������������)
    public static class Calculator
    {
        /// <summary>
        /// ��������� �������������� �������� ��� ����� �������.
        /// </summary>
        /// <param name="num1">������ �����</param>
        /// <param name="num2">������ �����</param>
        /// <param name="operation">�������� (+, -, *, /)</param>
        /// <returns>��������� ��������</returns>
        public static double Calculate(double num1, double num2, char operation)
        {
            return operation switch
            {
                '+' => num1 + num2, // ��������
                '-' => num1 - num2, // ���������
                '*' => num1 * num2, // ���������
                '/' => num2 != 0 ? num1 / num2 : throw new DivideByZeroException(), // �������
                _ => throw new InvalidOperationException("������������ ��������") // ������������ ����
            };
        }
    }
}
