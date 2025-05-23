using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число m");
        int m = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Введите число n");
        int n = Int32.Parse(Console.ReadLine());
        int[,] matrix = new int[m, n];

        FillMatrix(matrix);

        PrintMatrix(matrix);
        Console.ReadKey();
;    }

    static void FillMatrix(int[,] matrix)
    {
        Random random = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(0, 100); 
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],3} "); 
            }
            Console.WriteLine();
        }
    }
    // Метод для поиска элемента меньше заданного числа
    static void FindElementLessThan(int[,] matrix, int threshold)
    {
        bool found = false;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < threshold)
                {
                    Console.WriteLine($"Элемент меньше {threshold} найден по индексам: [{i}, {j}] со значением {matrix[i, j]}");
                    found = true;
                    return; // Выходим после нахождения первого элемента
                }
            }
        }

        if (!found)
        {
            Console.WriteLine($"Нет элементов меньше {threshold}.");
        }
    }

    // Метод для нахождения произведения нечетных элементов в каждой строке
    static void CalculateOddProduct(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int product = 1;
            bool hasOdd = false;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] % 2 != 0) // Проверка на нечетность
                {
                    product *= matrix[i, j];
                    hasOdd = true;
                }
            }

            if (hasOdd)
            {
                Console.WriteLine($"Произведение нечетных элементов в строке {i}: {product}");
            }
            else
            {
                Console.WriteLine($"В строке {i} нет нечетных элементов.");
            }
        }
    }
}
