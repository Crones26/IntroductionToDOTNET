#define ARRAYS_1
#define ARRAYS_2
#define JAGGED_ARRAYS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
	internal class Program
	{
		static readonly string delimiter = "\n--------------------------------------\n";
		static void Main(string[] args)
		{
			Random rand = new Random(0);
#if ARRAYS_1
			Console.Write("Введите размер массива: ");
			int n = Convert.ToInt32(Console.ReadLine());
			// int[] arr = { 3, 5, 8, 13, 21 }; // Пример массива с заранее заданными элементами
			int[] arr = new int[n];
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = rand.Next(100); // 0 ... IntMax
										 // Next(int upperLimit); // Возвращает случайное число до 'upperLimit'.
										 // Next(int lowerLimit, int upperLimit); // Возвращает случайное число в диапазоне от 'lowerLimit' до 'upperLimit'.
			}

			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i] + "\t");
			}
			Console.WriteLine();

			// foreach (int i in arr) // Range-based for
			// {
			//     Console.Write(i + "\t");
			// }
			// Console.WriteLine();

			// Находим сумму, среднее-арифметическое, минимальное и максимальное значение
			int sum1D = arr.Sum();
			double avg1D = arr.Average();
			int min1D = arr.Min();
			int max1D = arr.Max();

			Array.Sort(arr);

			Console.WriteLine(delimiter);
			Console.WriteLine($"Сумма: {sum1D}");
			Console.WriteLine($"Среднее арифметическое: {avg1D}");
			Console.WriteLine($"Минимальное значение: {min1D}");
			Console.WriteLine($"Максимальное значение: {max1D}");
			Console.WriteLine("Отсортированный массив:");
			foreach (var item in arr)
			{
				Console.Write(item + "\t");
			}
			Console.WriteLine();
			Console.WriteLine(delimiter);
#endif

#if ARRAYS_2
			Console.Write("Введите количество строк: ");
			int rows = Convert.ToInt32(Console.ReadLine());

			Console.Write("Введите количество элементов строки: ");
			int cols = Convert.ToInt32(Console.ReadLine());

			int[,] i_arr_2 = new int[rows, cols];

			Console.WriteLine(i_arr_2.Rank);

			for (int i = 0; i < i_arr_2.GetLength(0); i++)
			{
				for (int j = 0; j < i_arr_2.GetLength(1); j++)
				{
					i_arr_2[i, j] = rand.Next(100);
				}
			}
			for (int i = 0; i < i_arr_2.GetLength(0); i++)
			{
				for (int j = 0; j < i_arr_2.GetLength(1); j++)
				{
					Console.Write(i_arr_2[i, j] + "\t");
				}
				Console.WriteLine();
			}

			// Находим сумму, среднее-арифметическое, минимальное и максимальное значение
			int sum2D = i_arr_2.Cast<int>().Sum();
			double avg2D = i_arr_2.Cast<int>().Average();
			int min2D = i_arr_2.Cast<int>().Min();
			int max2D = i_arr_2.Cast<int>().Max();

			var sorted2D = i_arr_2.Cast<int>().OrderBy(x => x).ToArray();

			Console.WriteLine(delimiter);
			Console.WriteLine($"Сумма: {sum2D}");
			Console.WriteLine($"Среднее арифметическое: {avg2D}");
			Console.WriteLine($"Минимальное значение: {min2D}");
			Console.WriteLine($"Максимальное значение: {max2D}");
			Console.WriteLine("Отсортированный двумерный массив:");
			for (int i = 0; i < sorted2D.Length; i++)
			{
				Console.Write(sorted2D[i] + "\t");
				if ((i + 1) % cols == 0) Console.WriteLine();
			}
			Console.WriteLine();
			Console.WriteLine(delimiter);
#endif

#if JAGGED_ARRAYS
			// for (int a = 0, b = 1, c = a + b; a < 1000; a = b, b = c, c = a + b)
			//     Console.Write(a + "\t");
			// Console.WriteLine();

			int[][] arr_jagged = new int[][]
			{
				new int[]{ 0, 1, 1, 2 },
				new int[]{ 3, 5, 8, 13, 21 },
				new int[]{ 34, 55, 89 },
				new int[]{ 144, 233, 377, 610, 987 }
			};
			for (int i = 0; i < arr_jagged.Length; i++)
			{
				for (int j = 0; j < arr_jagged[i].Length; j++)
				{
					Console.Write(arr_jagged[i][j] + "\t");
				}
				Console.WriteLine();
			}

			// Находим сумму, среднее-арифметическое, минимальное и максимальное значение
			int sumJagged = arr_jagged.SelectMany(x => x).Sum();
			double avgJagged = arr_jagged.SelectMany(x => x).Average();
			int minJagged = arr_jagged.SelectMany(x => x).Min();
			int maxJagged = arr_jagged.SelectMany(x => x).Max();

			var sortedJagged = arr_jagged.SelectMany(x => x).OrderBy(x => x).ToArray();

			Console.WriteLine(delimiter);
			Console.WriteLine($"Сумма: {sumJagged}");
			Console.WriteLine($"Среднее арифметическое: {avgJagged}");
			Console.WriteLine($"Минимальное значение: {minJagged}");
			Console.WriteLine($"Максимальное значение: {maxJagged}");
			Console.WriteLine("Отсортированный зубчатый массив:");
			Console.WriteLine(delimiter);
			for (int i = 0; i < sortedJagged.Length; i++)
			{
				Console.Write(sortedJagged[i] + "\t");
				if ((i + 1) % 5 == 0) Console.WriteLine();
			}
			//foreach (var item in sortedJagged)
			//{
			//	Console.Write(item + "\t");
			//}
			Console.WriteLine();
#endif
		}
	}
}