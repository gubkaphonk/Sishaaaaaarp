using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int size = int.Parse(Console.ReadLine());
            double[] array = new double[size];

            
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Введите элемент {i + 1}: ");
                array[i] = double.Parse(Console.ReadLine());
            }

            double result = CalculateSquareRootOfSumOfSquares(array);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        static double CalculateSquareRootOfSumOfSquares(double[] array)
        {
            double sumOfSquares = 0;

            foreach (double number in array)
            {
                sumOfSquares += number * number;
            }

            return Math.Sqrt(sumOfSquares);
        }
    }
}
