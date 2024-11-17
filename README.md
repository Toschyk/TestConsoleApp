# TestConsoleApp
### Лабораторная работа: Разработка тестового сценария проекта

### Цель работы:
Научиться разрабатывать тестовые сценарии для проверки функциональности консольного приложения, созданного с использованием .NET Framework.  

### Ход работы:

#### 1. **Создание консольного приложения**
1. Откройте Visual Studio.
2. Создайте новый проект:
   - Шаблон: **Console App (.NET Framework)**.
   - Название: **TestConsoleApp**.
3. Реализуйте базовую функциональность приложения. Например, калькулятор, который выполняет базовые операции (сложение, вычитание, умножение, деление).
   
   ```csharp
   using System;

   namespace TestConsoleApp
   {
       class Program
       {
           static void Main(string[] args)
           {
               Console.WriteLine("Введите первое число:");
               double num1 = Convert.ToDouble(Console.ReadLine());

               Console.WriteLine("Введите операцию (+, -, *, /):");
               char operation = Convert.ToChar(Console.ReadLine());

               Console.WriteLine("Введите второе число:");
               double num2 = Convert.ToDouble(Console.ReadLine());

               double result = 0;

               switch (operation)
               {
                   case '+':
                       result = num1 + num2;
                       break;
                   case '-':
                       result = num1 - num2;
                       break;
                   case '*':
                       result = num1 * num2;
                       break;
                   case '/':
                       result = num1 / num2;
                       break;
                   default:
                       Console.WriteLine("Некорректная операция.");
                       break;
               }

               Console.WriteLine($"Результат: {result}");
           }
       }
   }
   ```



#### 2. **Создание тестового сценария**
Тестовый сценарий описывает процесс тестирования функциональности. Он включает следующие элементы:
- **Цель теста**: Проверить корректность выполнения операций калькулятора.
- **Предусловия**: Установленное и работоспособное приложение.
- **Шаги выполнения теста**:
  1. Запустите приложение.
  2. Введите первое число (например, `10`).
  3. Введите операцию (например, `+`).
  4. Введите второе число (например, `5`).
  5. Проверьте отображаемый результат.
- **Ожидаемый результат**: Программа правильно выполняет арифметическую операцию (результат = `15`).



| **№** | **Шаги**                                | **Входные данные** | **Ожидаемый результат**        | **Статус**  |
|-------|-----------------------------------------|--------------------|---------------------------------|-------------|
| 1     | Запуск программы                        | -                  | Программа запущена             | Пройден     |
| 2     | Ввод первого числа                      | 10                 | Принято число `10`             | Пройден     |
| 3     | Ввод операции                           | `+`                | Принят знак операции `+`       | Пройден     |
| 4     | Ввод второго числа                      | 5                  | Принято число `5`              | Пройден     |
| 5     | Отображение результата                  | -                  | Результат: `15`                | Пройден     |
| 6     | Проверка обработки некорректных данных | `10`, `/`, `0`     | Ошибка: "Деление на ноль"      | Пройден     |



#### 3. **Реализация тестирования**
- **Ручное тестирование**: Выполните сценарий, следуя таблице. Зафиксируйте результаты.
- **Автоматизация тестирования**: 
   1. Подключите **NUnit** или **MSTest** для автоматического тестирования.
   2. Напишите тесты для каждого сценария.


```csharp
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
```
