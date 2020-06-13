using System;
using static System.Math;

namespace Lab1
{
    class Program1
    {
        static void Main(string[] args)
        {
            double alpha;
            Console.Write("Введите угол (в рад) и нажмите клавишу Enter: alpha = ");

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out alpha)) break;
                Console.WriteLine("Ошибка: нужно ввести число типа double!");
            }

            double z1 = Sin(PI / 2 + 3 * alpha) / (1 - Sin(3 * alpha - PI));
            Console.WriteLine($"Значение функции z1 = {z1}");
        }
    }
}

// Examples :
// 0.5 -> 0.0354
// -1 -> -1.1527
// 24 -> -0.7714