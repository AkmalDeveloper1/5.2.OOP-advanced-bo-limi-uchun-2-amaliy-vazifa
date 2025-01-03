using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5._2.OOP_advanced_bo_limi_uchun_2_amaliy_vazifa.Classes
{
    //-------------ranga bo'yash
    public static class Actions
    {
        public static void SetColor(string message, ConsoleColor color = ConsoleColor.Green)
        {
            ConsoleColor mainColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = mainColor;
        }
        public static void SetColorLine(string message, ConsoleColor color = ConsoleColor.Green)
        {
            ConsoleColor mainColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = mainColor;
        }
    }
}