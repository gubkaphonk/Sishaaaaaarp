using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11._2
{
    internal class Program
    {
        static void Main()
        {
            //Я не совсем понял что значит передать массив в качестве параметра. Предполагаю что в параметре массива ChangeSign, но не уверен, поэтому решил сделать такой ввод. 
            //Надеюсь лишним не будет.
            Console.Write("Введите размер массива: ");
            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Введите элемент {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            ChangeSign(array);

            Console.WriteLine("Массив после изменения знака:");
            PrintArray(array);
            Console.ReadKey();
        }

        static void ChangeSign(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -array[i]; 
            }
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
