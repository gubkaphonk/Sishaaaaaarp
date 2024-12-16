using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11._1a
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();

            Console.Write("Введите значение n\n");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите значение a\n");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите значение b\nOно должно быть больше чем a\n");
            int b = int.Parse(Console.ReadLine());

            if (a < -20 || a > 20 || b < a || b > 20)
            {
                Console.WriteLine("Ошибка в A и B");
                return;
                Console.ReadKey();
            }

            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(a, b + 1); 
            }

            PrintArray(array);
            Console.ReadKey();
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
                if (i < array.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(); 
        }
    }
}
