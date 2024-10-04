using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Game
{
	class Program
	{
		const int WIDTH = 40;
		const int HEIGHT = 20;

		static List<int> snakeX = new List<int>();
		static List<int> snakeY = new List<int>();

		static List<int> foodX = new List<int>();
		static List<int> foodY = new List<int>();

		static int dirX = 1;
		static int dirY = 0;

		static int score = 0;

		static int horizontalSpeed = 200;
		static int verticalSpeed = 300;

		static int minHorizontalSpeed = 50;
		static int minVerticalSpeed = 100;

		static int speedIncrease = 5;

		static void DrawBorders()
		{
			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Console.Write("╔");
			for (int i = 0; i < WIDTH; i++)
			{
				Console.Write("═");
			}
			Console.WriteLine("╗");

			for (int y = 1; y <= HEIGHT; y++)
			{
				Console.SetCursorPosition(0, y);
				Console.Write("║");
				Console.SetCursorPosition(WIDTH + 1, y);
				Console.Write("║");
			}

			Console.SetCursorPosition(0, HEIGHT + 1);
			Console.Write("╚");
			for (int i = 0; i < WIDTH; i++)
			{
				Console.Write("═");
			}
			Console.WriteLine("╝");
		}

		static void InitializeGame()
		{
			snakeX.Add(WIDTH / 2);
			snakeY.Add(HEIGHT / 2);
			DrawBorders();
		}

		static void HandleInput()
		{
			if (Console.KeyAvailable)
			{
				ConsoleKey key = Console.ReadKey(true).Key;

				switch (key)
				{
					case ConsoleKey.W:
					case ConsoleKey.UpArrow:
						if (dirY == 0) { dirX = 0; dirY = -1; }
						break;
					case ConsoleKey.S:
					case ConsoleKey.DownArrow:
						if (dirY == 0) { dirX = 0; dirY = 1; }
						break;
					case ConsoleKey.A:
					case ConsoleKey.LeftArrow:
						if (dirX == 0) { dirX = -1; dirY = 0; }
						break;
					case ConsoleKey.D:
					case ConsoleKey.RightArrow:
						if (dirX == 0) { dirX = 1; dirY = 0; }
						break;
				}
			}
		}

		static void UpdateSnakePosition()
		{
			int newX = snakeX[0] + dirX;
			int newY = snakeY[0] + dirY;

			if (newX <= 0 || newX >= WIDTH + 1 || newY <= 0 || newY >= HEIGHT + 1)
			{
				GameOver();
			}

			for (int i = 0; i < snakeX.Count; i++)
			{
				if (snakeX[i] == newX && snakeY[i] == newY)
				{
					GameOver();
				}
			}

			snakeX.Insert(0, newX);
			snakeY.Insert(0, newY);

			bool ateFood = false;

			// Проверяем, съела ли змейка еду
			for (int i = 0; i < foodX.Count; i++)
			{
				if (newX == foodX[i] && newY == foodY[i])
				{
					score++;
					ateFood = true;
					foodX.RemoveAt(i);
					foodY.RemoveAt(i);

					// Увеличиваем скорость игры
					if (horizontalSpeed > minHorizontalSpeed)
					{
						horizontalSpeed -= speedIncrease;
					}
					if (verticalSpeed > minVerticalSpeed)
					{
						verticalSpeed -= speedIncrease;
					}
					break;
				}
			}

			// Если еда не была съедена, убираем хвост змейки
			if (!ateFood)
			{
				Console.SetCursorPosition(snakeX[snakeX.Count - 1], snakeY[snakeY.Count - 1]);
				Console.Write(" ");
				snakeX.RemoveAt(snakeX.Count - 1);
				snakeY.RemoveAt(snakeY.Count - 1);
			}

			// Отображаем голову змейки
			Console.SetCursorPosition(snakeX[0], snakeY[0]);
			Console.Write("X");

			// Отображаем тело змейки как квадратики
			for (int i = 1; i < snakeX.Count; i++)
			{
				Console.SetCursorPosition(snakeX[i], snakeY[i]);
				Console.Write("O");
			}
		}

		static void GameOver()
		{
			Console.Clear();
			Console.SetCursorPosition(WIDTH / 2 - 5, HEIGHT / 2);
			Console.WriteLine($"Game Over! Final Score: {score}");
			Console.SetCursorPosition(WIDTH / 2 - 5, HEIGHT / 2 + 1);
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
			Environment.Exit(0);
		}

		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			InitializeGame();

			while (true)
			{
				HandleInput();
				UpdateSnakePosition();

				if (dirX != 0)
				{
					Thread.Sleep(horizontalSpeed);
				}
				else if (dirY != 0)
				{
					Thread.Sleep(verticalSpeed);
				}
			}
		}
	}
}