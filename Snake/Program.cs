using System;

namespace Snake
{
	class Program
	{
		static void Main(string[] args)
		{
			int x = 10, y = 10; // начальные координаты курсора
			ConsoleKey key;

			// Скрываем курсор
			Console.CursorVisible = false;

			try
			{
				do
				{
					Console.Clear();
					Console.SetCursorPosition(x, y);
					Console.Write("X"); // "курсор" в виде символа "X"

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
			finally
			{
				// Возвращаем видимость курсора
				Console.CursorVisible = true;
			}
		}
	}
}
