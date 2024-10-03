#define DECIMAL
//#define BIG_INTEGER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics; // Пространство имён для BigInteger(Добавил ручками,т.к. студия не видела)

namespace Factorial
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int number;

#if DECIMAL
			do
			{
				Console.Write("Введите число (от 0 до 28): ");

				if (int.TryParse(Console.ReadLine(), out number))
				{
					if (number < 0)
					{
						Console.WriteLine("Число должно быть положительным. Попробуйте снова.");
					}
					else if (number > 27)
					{
						Console.WriteLine("Факториал слишком велик для стандартных типов данных. Введите число меньше 28.");
					}
					else
					{
						break;
					}
				}
				else
				{
					Console.WriteLine("Введите корректное целое число.");
				}
			} while (true);

			decimal factorial = CalculateFactorial(number);
			Console.WriteLine($"Факториал {number} = {factorial}");
		}
		// Метод для вычисления факториала с использованием типа decimal
		static decimal CalculateFactorial(int n)
		{
			decimal result = 1;
			for (int i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}
#endif

#if BIG_INTEGER
			do
			{
				Console.Write("Введите число: ");

				if (int.TryParse(Console.ReadLine(), out number))
				{
					if (number >= 0)
					{
						break;
					}
					else
					{
						Console.WriteLine("Число должно быть положительным. Попробуйте снова.");
					}
				}
				else
				{
					Console.WriteLine("Введите корректное целое число.");
				}
			} while (true);
			BigInteger factorial = CalculateFactorial(number);
			Console.WriteLine($"Факториал {number} = {factorial}");
		}
		// Метод для вычисления факториала с использованием BigInteger
		static BigInteger CalculateFactorial(int n)
		{
			BigInteger result = 1;
			for (int i = 2; i <= n; i++)
			{
				result *= i;
			}
			return result;
		} 
#endif

	}
}
