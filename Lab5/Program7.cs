using System;
//using System.Linq;

namespace Lab4_2
{
    class Program7
    {
        static void Main(string[] args)
        {
            var array = ReadArrayFromConsole();
            PrintArray(SortArray(array));
            CountNegativeElements(SortArray(array));
        }

        static int ReadNumber(string text)
        {
            int number;
            Console.Write(text);

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out number) && number != 0) break;
                Console.WriteLine("Ошибка: нужно ввести натуральное число!");
            }

            return number;
        }

        static int[,] ReadArrayFromConsole()
        {
            Console.WriteLine("Введите размерность массива: ");

            int n = ReadNumber("Кол-во строк: "), m = ReadNumber("Кол-во столбцов: ");
            var array = new int[n, m];

            Console.WriteLine("Введите массив целых чисел по строкам: ");

            for (int i = 0; i < n; i++)
            {
                Console.Write("[{0} строка]: ", i + 1);

                bool flag = false;
                while (!flag)
                {
                    string[] row = Console.ReadLine().Split(" ");
                    if (row.Length != m) Console.Write("Ошибка: количество элементов в строке не равно {0}!\nВведите строку ещё раз: ", m);
                    else
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (int.TryParse(row[j], out array[i, j])) flag = true;
                            else
                            {
                                flag = false;
                                Console.Write("Ошибка: строка должна состоять только из целых чисел!\nВведите строку ещё раз: ");
                                break;
                            }
                        }
                    }
                }
            }

            return array;
        }

        static int[,] SortArray(int[,] array)
        {
            //var newArray = array.ToList().OrderByDescending(x => x.ToList().GroupBy(y => y).Select(z => z.Count()).ToList().Max()).ToArray();

            int n = array.GetLength(0), m = array.GetLength(1);

            int[] selectRow = new int[m];
            int[] countOfEqualElements = new int[m];
            int[] maxOfEqualElements = new int[n];

            // Create an array of maxOfEqualElements 
            for (int i = 0; i < array.GetLength(0); i++)
            {
                //Take the SelectRow from Array
                for (int j = 0; j < m; j++)
                {
                    selectRow[j] = array[i, j];
                }

                //Find countOfEqualElements in the SelectRow
                for (int j1 = 0; j1 < m; j1++)
                {
                    for (int j2 = 0; j2 < m; j2++)
                    {
                        if (selectRow[j1] == selectRow[j2]) countOfEqualElements[j1] += 1;
                    }
                }

                //Find maxOfEqualElement in the SelectRow
                for (int j = 0; j < m; j++)
                {
                    if (countOfEqualElements[j] > maxOfEqualElements[i]) maxOfEqualElements[i] = countOfEqualElements[j];
                }

                //Set to zero array 'countOfEqualElements'
                for (int j = 0; j < m; j++) countOfEqualElements[j] = 0;
            }

            // Sort array 'maxOfEqualElement'
            int[] sortMaxOfEqualElements = new int[n];
            Array.Copy(maxOfEqualElements, sortMaxOfEqualElements, n);
            Array.Sort(sortMaxOfEqualElements);
            Array.Reverse(sortMaxOfEqualElements);

            var newArray = new int[n, m];

            for (int i = 0; i < n; i++) //sortMax array
            {
                for (int j = 0; j < n; j++) // max array
                {
                    if (sortMaxOfEqualElements[i] == maxOfEqualElements[j])
                    {
                        for (int k = 0; k < m; k++) newArray[i, k] = array[j, k];
                        maxOfEqualElements[j] = 0;
                        break;
                    }
                }
            }

            return newArray;
        }

        static void PrintArray(int[,] newArray)
        {
            Console.WriteLine("Отсортированный массив:");

            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < newArray.GetLength(1); j++) Console.Write(newArray[i, j] + " ");
                Console.WriteLine();
            }
        }

        static void CountNegativeElements(int[,] newArray)
        {
            int countNegative = 0;
            bool ifZero = false;

            for (int i = 0; i < newArray.GetLength(0); i++)
            {
                for (int j = 0; j < newArray.GetLength(1); j++)
                {
                    if (newArray[i, j] < 0) countNegative++;
                    if (newArray[i, j] == 0) ifZero = true;
                }

                if (ifZero)
                {
                    Console.WriteLine("В {0}-й строке {1} отрицательных элементов", i + 1, countNegative);
                    ifZero = false;
                }
                else Console.WriteLine("В {0}-й строке нет ни одного нуля", i + 1);

                countNegative = 0;
            }
        }
    }
}