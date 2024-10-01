using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard_HARD
{
	internal class Program
	{
		// Определяем символы для рамки и шахматных клеток (используем символы из ASCII)
		/*const char UP_LEFT_ANGLE = (char)0x250C;  // Символ '┌'
		const char UP_RIGHT_ANGLE = (char)0x2510;   // Символ '┐'
		const char LOW_LEFT_ANGLE = (char)0x2514;   // Символ '└'
		const char LOW_RIGHT_ANGLE = (char)0x2518;  // Символ '┘'
		const char HORIZONT_LINE = (char)0x2500;    // Символ '─'
		const char VERTICAL_LINE = (char)0x2502;    // Символ '│'
		const string WHITE_BOX = "\u2588\u2588\u2588\u2588";  // Белая клетка (символ "█" в несколько раз)
		const string BLACK_BOX = "    ";            // Черная клетка*/
		const char UP_LEFT_ANGLE = '┌';
		const char UP_RIGHT_ANGLE = '┐';
		const char LOW_LEFT_ANGLE = '└';
		const char LOW_RIGHT_ANGLE = '┘';
		const char HORIZONT_LINE = '─';
		const char VERTICAL_LINE = '│';
		const string WHITE_BOX = "████";
		const string BLACK_BOX = "    ";
		static void Main(string[] args)
		{
			/*Console.WriteLine("Введите размер шахматной доски: ");
			int size = Convert.ToInt32(Console.ReadLine());
			// Рисуем шахматную доску
			for (int i = 0; i <= size; ++i)
			{
				for (int j = 0; j <= size; ++j)
				{
					if (i == 0 && j == 0)
						Console.Write(UP_LEFT_ANGLE);  // Левый верхний угол
					else if (i == 0 && j == size)
						Console.Write(UP_RIGHT_ANGLE); // Правый верхний угол
					else if (i == size && j == size)
						Console.Write(LOW_RIGHT_ANGLE); // Правый нижний угол
					else if (i == size && j == 0)
						Console.Write(LOW_LEFT_ANGLE); // Левый нижний угол
					else if (i == 0 || i == size)
						Console.Write(HORIZONT_LINE); // Горизонтальная линия
					else if (j == 0 || j == size)
						Console.Write(VERTICAL_LINE); // Вертикальная линия
					else
						// Чередуем черные и белые клетки
						Console.Write(i % 2 == j % 2 ? WHITE_BOX : BLACK_BOX);
				}
				Console.WriteLine();
			}*/

			int n;
			do
			{
				Console.Write("Введите размер доски (от 6 до 12): ");
				if (!int.TryParse(Console.ReadLine(), out n) || n <= 6 || n > 12)
				{
					Console.WriteLine("Неверный ввод! Пожалуйста, введите корректный размер доски(от 6 до 12). ");
				}
			} while (n <= 5 || n > 12);
			DrawChessboard(n);
		}
		static void DrawChessboard(int n)
		{
			// Рисуем верхнюю рамку
			Console.Write(UP_LEFT_ANGLE);
			Console.Write(new string(HORIZONT_LINE, n * 4));
			Console.WriteLine(UP_RIGHT_ANGLE);
			// Рисуем шахматные клетки
			for (int i = 0; i < n; i++)
			{
				for (int k = 0; k < 2; k++) // Увеличиваем высоту каждой клетки до 2 строк
				{
					Console.Write(VERTICAL_LINE); // Левая вертикальная рамка
					for (int j = 0; j < n; j++)
					{
						// Чередуем черные и белые клетки
						Console.Write((i + j) % 2 == 0 ? WHITE_BOX : BLACK_BOX);
					}
					Console.WriteLine(VERTICAL_LINE); // Правая вертикальная рамка
				}
			}
			// Рисуем нижнюю рамку
			Console.Write(LOW_LEFT_ANGLE);
			Console.Write(new string(HORIZONT_LINE, n * 4));
			Console.WriteLine(LOW_RIGHT_ANGLE);
		}
	}
}