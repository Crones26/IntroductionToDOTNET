using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int n;

			// 1) Прямоугольник n x n
			Console.Write("Введите размер для фигуры 1: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("\n1)");
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}

			// 2) Треугольник слева направо
			Console.Write("Введите размер для фигуры 2: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("\n2)");
			for (int i = 1; i <= n; i++)
			{
				for (int j = 0; j < i; j++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}

			// 3) Обратный треугольник
			Console.Write("Введите размер для фигуры 3: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("\n3)");
			for (int i = n; i >= 1; i--)
			{
				for (int j = 0; j < i; j++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}

			// 4) Смещенный вправо треугольник
			Console.Write("Введите размер для фигуры 4: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("\n4)");
			for (int i = n; i >= 1; i--)
			{
				for (int j = n; j > i; j--)
				{
					Console.Write(" ");
				}
				for (int k = 0; k < i; k++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}

			// 5) Смещенный влево треугольник
			Console.Write("Введите размер для фигуры 5: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("\n5)");
			for (int i = 1; i <= n; i++)
			{
				for (int j = n; j > i; j--)
				{
					Console.Write(" ");
				}
				for (int k = 0; k < i; k++)
				{
					Console.Write("*");
				}
				Console.WriteLine();
			}

			// 6) Ромб
			Console.Write("Введите размер для фигуры 6: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("\n6)");
			// Верхняя часть ромба
			for (int i = 0; i < n; i++)
			{
				for (int j = i; j < n; j++)
					Console.Write(" ");  // Левые пробелы
				Console.Write("/");      // Левая часть ромба

				for (int j = 0; j < i * 2; j++)
					Console.Write(" ");  // Пробелы между "/ " и " \\"

				Console.Write("\\");     // Правая часть ромба
				Console.WriteLine();
			}

			// Нижняя часть ромба
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j <= i; j++)
					Console.Write(" ");  // Левые пробелы
				Console.Write("\\");     // Левая часть ромба

				for (int j = (n - i - 1) * 2; j > 0; j--)
					Console.Write(" ");  // Пробелы между "\ " и " /"

				Console.Write("/");      // Правая часть ромба
				Console.WriteLine();
			}

			// 7) Шахматная доска
			Console.Write("Введите размер для фигуры 7: ");
			n = int.Parse(Console.ReadLine());
			Console.WriteLine("\n7)");
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if ((i + j) % 2 == 0)
					{
						Console.Write("+ ");
					}
					else
					{
						Console.Write("- ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}
