using System;
using static System.Math;

namespace Lab2_2
{
    class Program3
    {
        static void Main(string[] args)
        {
            double R = ReadNumber("Введите параметр R и нажмите клавишу Enter: R = ");
            double x = ReadNumber("Введите коородинаты точки: \nx = ");
            double y = ReadNumber("y = ");
            HitPoint(R, x, y);
        }

        static double ReadNumber(string text)
        {
            double number;
            Console.Write(text);

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out number)) break;
                Console.WriteLine("Ошибка: нужно ввести число типа double!");
            }

            return number;
        }

        static void HitPoint(double R, double x, double y)
        {
            if ((x >= -2 * R) && (x <= 0) && (y >= -2 * R) && (y <= 0) && (y >= (-x - 2 * R))) Console.WriteLine("Point is INSIDE the area");
            else if ((x >= 0) && (x <= 2 * R) && (y >= 0) && (y <= 2 * R) && (Pow(y, 2) >= Pow(R, 2) - Pow(x, 2))) Console.WriteLine("Point is INSIDE the area");
            else Console.WriteLine("Point is OUTSIDE the area");
        }
    }
}