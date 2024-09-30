//#define CONSOLE_CLASS
//#define STRING_OPERATIONS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOTNET
{
	internal class Program
	{
		static readonly string delimiter = "\n---------------------------------------\n";
		static void Main(string[] args)
		{
#if CONSOLE_CLASS
			Console.Title = "Introduction to .NET";
			Console.WriteLine("Hello .NET:");
			//Console.CursorLeft = 25;
			//Console.CursorTop = 8;
			Console.SetCursorPosition(24, 5);
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("Привет .NET:");
			Console.ResetColor();

			Console.WriteLine(delimiter);

			Console.WriteLine("Позиция окна консоли: " + Console.WindowLeft + " знакопозиций");
			Console.WriteLine("Позиция окна консоли: " + Console.WindowTop + " знакопозиций");

			Console.SetWindowSize(91, 22);
			Console.WriteLine("Ширина окна консоли: " + Console.WindowWidth + " знакопозиций");
			Console.WriteLine("Высота окна консоли: " + Console.WindowHeight + " знакопозиций");

			Console.SetBufferSize(91, 22);
			Console.WriteLine("Ширина буфера консоли: " + Console.BufferWidth + " знакопозиций");
			Console.WriteLine("Высота буфера консоли: " + Console.BufferHeight + " знакопозиций"); 
#endif
#if STRING_OPERATIONS
			Console.Write("Введитк Ваше Имя: ");
			string first_name = Console.ReadLine();

			Console.Write("Введите Вашу Фамилию: ");
			string last_name = Console.ReadLine();

			Console.Write("Введите Ваш Возраст: ");
			int age = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine(first_name + " " + last_name + " " + age); // Конкатенация строк
			Console.WriteLine(String.Format("{0} {1} {2}", first_name, last_name, age)); // Форматирование строк
			Console.WriteLine($"{first_name} {last_name} {age}"); // Интерполяция строк  
#endif

		}
	}
}
