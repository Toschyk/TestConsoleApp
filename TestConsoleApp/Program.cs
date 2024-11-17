using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Сообщаем пользователю, что необходимо ввести первое число
            Console.WriteLine("Введите первое число:");
            double num1 = Convert.ToDouble(Console.ReadLine()); // Читаем и преобразуем ввод пользователя в число

            // Сообщаем пользователю, что необходимо выбрать операцию
            Console.WriteLine("Введите операцию (+, -, *, /):");
            char operation = Convert.ToChar(Console.ReadLine()); // Читаем символ операции

            // Сообщаем пользователю, что необходимо ввести второе число
            Console.WriteLine("Введите второе число:");
            double num2 = Convert.ToDouble(Console.ReadLine()); // Читаем и преобразуем ввод пользователя в число

            double result = 0; // Переменная для хранения результата

            // Используем конструкцию switch для выполнения операции в зависимости от введенного знака
            switch (operation)
            {
                case '+': // Если операция сложения
                    result = num1 + num2;
                    break;
                case '-': // Если операция вычитания
                    result = num1 - num2;
                    break;
                case '*': // Если операция умножения
                    result = num1 * num2;
                    break;
                case '/': // Если операция деления
                    if (num2 != 0) // Проверяем, что деление на ноль не производится
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: Деление на ноль невозможно.");
                        return; // Завершаем выполнение программы, если ошибка
                    }
                    break;
                default: // Если введена некорректная операция
                    Console.WriteLine("Некорректная операция.");
                    return; // Завершаем выполнение программы
            }

            // Выводим результат пользователю
            Console.WriteLine($"Результат: {result}");
            Console.ReadLine();
        }
    }
}
