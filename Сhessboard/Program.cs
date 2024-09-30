using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер доски: ");
			int boardSize = int.Parse(Console.ReadLine());
			Console.Write("Введите размер клетки: ");
			int cellSize = int.Parse(Console.ReadLine());
			
			for (int row = 0; row < boardSize; row++)
			{
				for (int cellRow = 0; cellRow < cellSize; cellRow++) // количество строк в одной клетке
				{
					for (int col = 0; col < boardSize; col++)
					{
						// Чередуем клетку в зависимости от позиции
						if ((row + col) % 2 == 0)
						{
							for (int cellCol = 0; cellCol < cellSize; cellCol++) // количество столбцов в одной клетке
							{
								Console.Write("* ");
							}
						}
						else
						{
							for (int cellCol = 0; cellCol < cellSize; cellCol++) // пустая клетка
							{
								Console.Write("  ");
							}
						}
					}
					Console.WriteLine();
				}
			}
			Console.ReadKey();
		}
	}
}
