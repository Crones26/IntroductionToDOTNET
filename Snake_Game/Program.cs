using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{
	internal class Program
	{
		const int WIDTH = 40;
		const int HEIGHT = 20;

		// Функция для отрисовки игрового поля
		static void DrawField()
		{
			// Верхняя граница
			Console.Write("╔");
			for (int i = 0; i < WIDTH; i++)
			{
				Console.Write("═");
			}
			Console.WriteLine("╗");

			// Боковые границы
			for (int i = 0; i < HEIGHT; i++)
			{
				Console.Write("║");
				for (int j = 0; j < WIDTH; j++)
				{
					Console.Write(" "); // Пустое пространство внутри поля
				}
				Console.WriteLine("║");
			}

			// Нижняя граница
			Console.Write("╚");
			for (int i = 0; i < WIDTH; i++)
			{
				Console.Write("═");
			}
			Console.WriteLine("╝");
		}

		static void Main(string[] args)
		{
			DrawField();
			Console.ReadKey(); // Ожидание нажатия клавиши, чтобы окно не закрывалось сразу
		}
	}
}