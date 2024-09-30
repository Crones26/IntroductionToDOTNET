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

            Console.SetWindowSize(91, 22);
            Console.WriteLine("Ширина окна консоли: "+Console.WindowWidth  + " знакопозиций");
            Console.WriteLine("Высота окна консоли: "+Console.WindowHeight + " знакопозиций");

            Console.SetBufferSize(91, 22);
            Console.WriteLine("Ширина буфера консоли: "+Console.BufferWidth  + " знакопозиций");
            Console.WriteLine("Высота буфера консоли: "+Console.BufferHeight + " знакопозиций");

        }
    }
}
