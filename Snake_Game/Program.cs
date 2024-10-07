using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Game
{
	internal class Program
	{
		const int WIDTH = 60;
		const int HEIGHT = 30;

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

		static bool isPaused = false;  // Переменная для отслеживания паузы

		static void DrawBorders()
		{
			// Устанавливаем красный цвет для рамки
			Console.ForegroundColor = ConsoleColor.Red;

			// Рисуем верхнюю границу
			for (int x = 0; x < WIDTH + 2; x++)
			{
				Console.SetCursorPosition(x, 0);
				Console.Write("═");
			}
			// Рисуем нижнюю границу
			for (int x = 0; x < WIDTH + 2; x++)
			{
				Console.SetCursorPosition(x, HEIGHT + 1);
				Console.Write("═");
			}
			// Рисуем левую и правую границы
			for (int y = 0; y < HEIGHT + 2; y++)
			{
				Console.SetCursorPosition(0, y);
				Console.Write("║");
				Console.SetCursorPosition(WIDTH + 1, y);
				Console.Write("║");
			}
			// Углы
			Console.SetCursorPosition(0, 0);
			Console.Write("╔");

			Console.SetCursorPosition(WIDTH + 1, 0);
			Console.Write("╗");

			Console.SetCursorPosition(0, HEIGHT + 1);
			Console.Write("╚");

			Console.SetCursorPosition(WIDTH + 1, HEIGHT + 1);
			Console.Write("╝");

			// Возвращаем цвет в исходное состояние
			Console.ResetColor();
		}

		static void InitializeGame()
		{
			if (Console.LargestWindowWidth >= WIDTH + 2 && Console.LargestWindowHeight >= HEIGHT + 3)
			{
				Console.SetWindowSize(WIDTH + 2, HEIGHT + 3);
				Console.SetBufferSize(WIDTH + 2, HEIGHT + 3);
			}
			snakeX.Add(WIDTH / 2);
			snakeY.Add(HEIGHT / 2);
			GenerateFood();
			DrawBorders();
			UpdateScore();
		}

		static void GenerateFood()
		{
			Random random = new Random();
			while (foodX.Count < 3)
			{
				int newFoodX = random.Next(1, WIDTH);
				int newFoodY = random.Next(1, HEIGHT);

				if (!snakeX.Contains(newFoodX) || !snakeY.Contains(newFoodY))
				{
					foodX.Add(newFoodX);
					foodY.Add(newFoodY);
				}
			}
		}

		static void UpdateScore()
		{
			Console.SetCursorPosition(1, HEIGHT + 2);
			Console.Write($"Score: {score}");
		}

		static void DrawFood()
		{
			// Устанавливаем синий цвет для еды
			Console.ForegroundColor = ConsoleColor.Blue;
			for (int i = 0; i < foodX.Count; i++)
			{
				Console.SetCursorPosition(foodX[i], foodY[i]);
				Console.Write("■");
			}
			// Возвращаем цвет в исходное состояние
			Console.ResetColor();
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
					case ConsoleKey.Spacebar:
						// Включаем или выключаем паузу
						isPaused = !isPaused;
						if (isPaused)
						{
							Console.SetCursorPosition(WIDTH / 2 - 5, HEIGHT + 2);
							Console.Write("Game Paused");
						}
						else
						{
							Console.SetCursorPosition(WIDTH / 2 - 5, HEIGHT + 2);
							Console.Write(new string(' ', 11));  // Стираем сообщение о паузе
						}
						break;
					case ConsoleKey.Escape:
						// Выход из игры
						Environment.Exit(0);
						break;
				}
			}
		}

		static void UpdateSnakePosition()
		{
			if (isPaused) return;  // Если игра на паузе, не обновляем позицию змейки
			int newX = snakeX[0] + dirX;
			int newY = snakeY[0] + dirY;
			// Проверка выхода за границы поля
			if (newX <= 0 || newX >= WIDTH + 1 || newY <= 0 || newY >= HEIGHT + 1)
			{
				GameOver();
				return;
			}
			// Проверка на столкновение змейки с телом 
			for (int i = 0; i < snakeX.Count; i++)
			{
				if (snakeX[i] == newX && snakeY[i] == newY)
				{
					GameOver();
					return;
				}
			}
			snakeX.Insert(0, newX);
			snakeY.Insert(0, newY);

			bool ateFood = false;
			// Проверка на поедание еды
			for (int i = 0; i < foodX.Count; i++)
			{
				if (newX == foodX[i] && newY == foodY[i])
				{
					score++;
					UpdateScore();
					ateFood = true;
					foodX.RemoveAt(i);
					foodY.RemoveAt(i);
					GenerateFood();

					// Увеличиваем скорость при поедании еды
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
			if (!ateFood)
			{
				// Удаляем хвост змейки
				Console.SetCursorPosition(snakeX[snakeX.Count - 1], snakeY[snakeY.Count - 1]);
				Console.Write(" ");
				snakeX.RemoveAt(snakeX.Count - 1);
				snakeY.RemoveAt(snakeY.Count - 1);
			}
			// Устанавливаем зелёный цвет для змейки
			Console.ForegroundColor = ConsoleColor.Green;
			// Проверяем, что новые координаты в пределах консоли, перед вызовом SetCursorPosition
			if (newX >= 0 && newX < WIDTH + 2 && newY >= 0 && newY < HEIGHT + 2)
			{
				Console.SetCursorPosition(snakeX[0], snakeY[0]);
				Console.Write("X");
			}
			for (int i = 1; i < snakeX.Count; i++)
			{
				if (snakeX[i] >= 0 && snakeX[i] < WIDTH + 2 && snakeY[i] >= 0 && snakeY[i] < HEIGHT + 2)
				{
					Console.SetCursorPosition(snakeX[i], snakeY[i]);
					Console.Write("O");
				}
			}
			// Возвращаем цвет в исходное состояние
			Console.ResetColor();
		}

		static void GameOver()
		{
			Console.Clear();
			Console.SetCursorPosition(WIDTH / 2 - 5, HEIGHT / 2);
			Console.WriteLine($"Game Over! Final Score: {score}");
			Console.SetCursorPosition(WIDTH / 2 - 10, HEIGHT / 2 + 1);
			Console.WriteLine("Press R to restart or Q to quit.");

			while (true)
			{
				// Ожидаем нажатия клавиши
				ConsoleKey key = Console.ReadKey(true).Key;

				if (key == ConsoleKey.R)
				{
					// Перезапускаем игру
					RestartGame();
					break;
				}
				else if (key == ConsoleKey.Q || key == ConsoleKey.Escape)
				{
					// Завершаем игру
					Environment.Exit(0);
				}
			}
		}

		static void RestartGame()
		{
			// Очищаем консоль
			Console.Clear();
			// Сбрасываем все параметры и данные
			snakeX.Clear();
			snakeY.Clear();
			foodX.Clear();
			foodY.Clear();
			dirX = 1;
			dirY = 0;
			score = 0;
			horizontalSpeed = 200;
			verticalSpeed = 300;
			// Заново инициализируем игру
			InitializeGame();
		}

		static void Main(string[] args)
		{
			Console.CursorVisible = false;
			InitializeGame();

			while (true)
			{
				HandleInput();
				if (!isPaused)
				{
					UpdateSnakePosition();
					DrawFood();
				}

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