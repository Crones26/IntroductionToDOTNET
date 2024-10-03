using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			int x = 10, y = 10; // начальные координаты курсора
			ConsoleKey key;

			do
			{
				Console.Clear();
				Console.SetCursorPosition(x, y);
				Console.Write("\u2588"); // "курсор" в виде заполненного квадратика из ASCII

				key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.W:
					case ConsoleKey.UpArrow:
						y = Math.Max(0, y - 1); // двигаем курсор вверх
						break;
					case ConsoleKey.S:
					case ConsoleKey.DownArrow:
						y = Math.Min(Console.WindowHeight - 1, y + 1); // вниз
						break;
					case ConsoleKey.A:
					case ConsoleKey.LeftArrow:
						x = Math.Max(0, x - 1); // влево
						break;
					case ConsoleKey.D:
					case ConsoleKey.RightArrow:
						x = Math.Min(Console.WindowWidth - 1, x + 1); // вправо
						break;
				}
			} while (key != ConsoleKey.Escape); // программа завершится при нажатии Escape
		}
	}
}
