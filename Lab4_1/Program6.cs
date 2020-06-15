using System;

namespace Lab4_1
{
    class Program6
    {
        static void Main(string[] args)
        {
            ComputeNumbers(ReadArrayFromConsole());
        }

        static double[] ReadArrayFromConsole()
        {
            bool flag = false;
            double[] numbers = null;
            Console.Write("Введите массив чисел: ");

            while (!flag)
            {
                string[] arr = Console.ReadLine().Split(" ");
                numbers = new double[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (double.TryParse(arr[i], out numbers[i]))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        Console.Write("Ошибка: один из элементов не является числом типа double!\nВведите массив ещё раз: ");
                        break;
                    }
                }
            }

            return numbers;
        }

        static void ComputeNumbers(double[] numbers)
        {
            double product = 1, max = numbers[0], beforeMaxSum = 0;
            int negCount = 0, maxIdx = 0, n = numbers.Length;

            for (int i = 0; i < n; i++)
            {
                // Product of negative elements
                if (numbers[i] < 0)
                {
                    negCount += 1; // счётчик отрицательных элементов
                    product *= numbers[i];
                }

                // Finding index of MAX element
                if (numbers[i] > max)
                {
                    max = numbers[i];
                    maxIdx = i;
                }
            }

            // Sum of elements resided before MAX element
            for (int i = 0; i < maxIdx; i++) beforeMaxSum += numbers[i];

            // Transormation of array
            double[] newArray = new double[n];
            for (int i = 0; i < n; i++) newArray[i] = numbers[n - 1 - i];

            if (negCount == 0) Console.WriteLine("В массиве нет отрицательных элементов.");
            else Console.WriteLine("Произведение отрицательных элементов = {0}", product);
            Console.WriteLine("Сумма элементов, расположенных перед максимальным = {0}\nТрансформированный массив: {1}", beforeMaxSum, string.Join(" ", newArray));
        }
    }
}