using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер массива: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Введите элемент {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            long[] factorials = CalculateFactorials(array);

            
            foreach (long factorial in factorials)
            {
                Console.WriteLine(factorial);
            }
            Console.ReadKey();
        }

        public static long[] CalculateFactorials(int[] array)
        {
            long[] result = new long[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Factorial(Math.Abs(array[i]));
            }

            return result;
        }

        private static long Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
