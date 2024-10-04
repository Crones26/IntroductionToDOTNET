using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int x = 10, y = 10; // начальные координаты курсора
			ConsoleKey key;
			// Скрываем курсор
			Console.CursorVisible = false;
			// Устанавливаем начальное положение курсора и рисуем первый "X"
			Console.SetCursorPosition(x, y);
			Console.Write("X");
			do
			{
				key = Console.ReadKey(true).Key;
				// Убираем старый "X"
				Console.SetCursorPosition(x, y);
				Console.Write(" ");
				// Перемещаем курсор в зависимости от нажатой клавиши, следя за границами окна
				switch (key)
				{
					case ConsoleKey.UpArrow:
					case ConsoleKey.W: if (y > 0) y--;
						break;

					case ConsoleKey.DownArrow:
					case ConsoleKey.S: if (y < Console.WindowHeight - 1) y++;
						break;

					case ConsoleKey.LeftArrow:
					case ConsoleKey.A: if (x > 1) x -= 2;
						break;

					case ConsoleKey.RightArrow:
					case ConsoleKey.D: if (x < Console.WindowWidth - 2) x += 2;
						break;
				}
				// Рисуем "X" на новой позиции
				Console.SetCursorPosition(x, y);
				Console.Write("X");

			} while (key != ConsoleKey.Escape); // программа завершится при нажатии Escape
		}
	}
}