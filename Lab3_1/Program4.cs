using System;
using static System.Math;

namespace Lab3_1
{
    class Program4
    {
        static void Main(string[] args)
        {
            const double x1 = -9.0;
            const double x2 = 5.0;
            const double dx = 0.5;
            double y;

            Console.WriteLine("   X    ||    Y");
            Console.WriteLine("------------------");
            for (double x = x1; x <= x2; x += dx)
            {
                if (x <= -6) y = 1;
                else if (x <= -4) y = -0.5 * x - 2;
                else if (x <= 0) y = Sqrt(4 - Pow(x + 2, 2));
                else if (x <= 2) y = -Sqrt(1 - Pow(x - 1, 2));
                else y = -x + 2;

                Console.WriteLine(String.Format("{0,4:0.#}", x) + "    ||    " + String.Format("{0,-4:0.#####}", y));
            }
        }
    }
}