using System;
using static System.Math;

namespace Lab2_1
{
    class Program2
    {
        static void Main(string[] args)
        {
            double x, y;

            Console.Write("Введите аргумент x и нажмите клавишу Enter: x = ");

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out x)) break;
                Console.WriteLine("Ошибка: нужно ввести число типа double!");
            }

            if (x <= -6) y = 1;
            else if (x <= -4) y = -0.5 * x - 2;
            else if (x <= 0) y = Sqrt(4 - Pow(x + 2, 2));
            else if (x <= 2) y = -Sqrt(1 - Pow(x - 1, 2));
            else y = -x + 2;

            Console.WriteLine("y({0}) = {1}", x, y);
        }
    }
}