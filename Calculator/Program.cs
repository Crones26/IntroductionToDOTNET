//#define CALC_1
#define CALC_2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	internal class Program
	{
		static void Main(string[] args)
		{

#if CALC_1
			Console.WriteLine("Калькулятор!");
			while (true)
			{
				while (true)
				{
					#region Calc_0
					//Console.Write("Введите выражение: ");
					//string expresion = Console.ReadLine();
					//String[] tokens = expresion.Split('+', '-', '*', '/');
					//double a = Convert.ToDouble(tokens[0]);
					//double b = Convert.ToDouble(tokens[1]);
					//double result = 0;

					//if (expresion.Contains('+'))
					//	result = a + b;
					//else if (expresion.Contains('-'))
					//	result = a - b;
					//else if (expresion.Contains('*'))
					//	result = a * b;
					//else if (expresion.Contains('/'))
					//	result = a / b;
					//else
					//	Console.WriteLine("No operation");

					//Console.WriteLine($"{expresion} = {result}"); 
					#endregion

					Console.Write("Введите выражение: ");
					string expresion = Console.ReadLine();
					double result = 0;
					try
					{
						// Проверка на наличие операторов в выражении
						if (!expresion.Contains('+') && !expresion.Contains('-') &&
							!expresion.Contains('*') && !expresion.Contains('/'))
						{
							throw new ArgumentException("Выражение должно содержать хотя бы одну операцию (+, -, *, /).");
						}
						String[] tokens = expresion.Split('+', '-', '*', '/');
						// Проверка на количество элементов (должны быть только два числа)
						if (tokens.Length != 2)
						{
							throw new ArgumentException("Выражение должно содержать два числа.");
						}
						double a = Convert.ToDouble(tokens[0]);
						double b = Convert.ToDouble(tokens[1]);
						// Определение операции
						if (expresion.Contains('+'))      result = a + b;
						else if (expresion.Contains('-')) result = a - b;
						else if (expresion.Contains('*')) result = a * b;
						else if (expresion.Contains('/'))
						{
							// Проверка деления на ноль
							if (b == 0)
							{
								throw new DivideByZeroException("Ошибка: деление на ноль невозможно.");
							}
							result = a / b;
						}

						Console.WriteLine($"{expresion} = {result}");
						// Выход из внутреннего цикла, если выражение было введено корректно
						break;
					}
					catch (FormatException)
					{
						Console.WriteLine("Ошибка: неверный формат числа. Убедитесь, что вы вводите корректные числа.");
					}
					catch (DivideByZeroException ex)
					{
						Console.WriteLine(ex.Message);
					}
					catch (ArgumentException ex)
					{
						Console.WriteLine(ex.Message);
					}
				}
				// Запрос на продолжение
				Console.Write("Хотите ввести другое выражение? (y/n): ");
				string continueInput = Console.ReadLine().ToLower();
				if (continueInput != "y")
				{
					break;  // Выход из внешнего цикла, если пользователь не хочет продолжать
				}
			}

#endif

#if CALC_2
			Console.WriteLine("Калькулятор!");
			while (true)
			{
				try
				{
					Console.Write("Введите первое число: ");
					//double num1 = double.Parse(Console.ReadLine());
					double num1 = Convert.ToDouble(Console.ReadLine());

					Console.Write("Выберете оператор (+, -, *, /): ");
					char operation = Console.ReadKey().KeyChar;
					Console.WriteLine();

					Console.Write("Введите второе число: ");
					//double num2 = double.Parse(Console.ReadLine());
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
							if (num2 != 0)
							{
								result = num1 / num2;
							}
							else
							{
								Console.WriteLine("Ошибка: деление на ноль невозможно.");
								continue;
							}
							break;
						default:
							Console.WriteLine("Ошибка: неизвестный оператор.");
							continue;
					}
					Console.WriteLine($"Результат: {num1} {operation} {num2} = {result}");
				}
				catch (FormatException)
				{
					Console.WriteLine("Ошибка: неверный ввод числа. Попробуйте снова.");
				}
				Console.Write("Хотите продолжить? (y/n): ");
				if (Console.ReadLine().ToLower() != "y")
				{
					break;
				}
			}
#endif

		}
	}
}
