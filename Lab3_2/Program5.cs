using System;
using static System.Math;

namespace Lab3_2
{
    class Program5
    {
        static void Main(string[] args)
        {
            double x1 = ReadX("Введите x1 и нажмите клавишу Enter: x1 = ");
            double x2 = ReadX("Введите x2 и нажмите клавишу Enter: x2 = ");
            double dx = ReadNumber("Введите dx и нажмите клавишу Enter: dx = ");
            double E = ReadNumber("Введите E и нажмите клавишу Enter: E = ");
            TaylorSeries(x1, x2, dx, E);
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

        static double ReadX(string text)
        {
            double x;
            Console.Write(text);

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out x) && Abs(x) <= 1) break;
                Console.WriteLine("Ошибка: аргумент Х должен быть типа double и |x| <= 1");
            }

            return x;
        }

        static void TaylorSeries(double x1, double x2, double dx, double E)
        {
            Console.WriteLine("   X    ||    Y");
            Console.WriteLine("------------------");
            for (double x = x1; x <= x2; x += dx)
            {
                int n = 0;
                double e = Pow(-1, n + 1) * Pow(x, 2 * n + 1) / (2 * n + 1);
                double y = PI / 2;

                while (Abs(e) > E)
                {
                    e = Pow(-1, n + 1) * Pow(x, 2 * n + 1) / (2 * n + 1);
                    y += e;
                    n++;
                }

                Console.WriteLine(String.Format("{0,4:0.#####}", x) + "    ||    " + String.Format("{0,-4:0.#####}", y));
            }
        }
    }
}