using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Введите число 1.");
            double digit1 = 0;
            digit1=double.Parse(Console.ReadLine());
            Console.WriteLine("Введите число 2.");
            double digit2 = 0;
            digit2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите число 3.");
            double digit3 = 0;
            digit3 = double.Parse(Console.ReadLine());

            double AlgebrAvrg = (digit1 + digit2 + digit3) / 3;
            double GeomAvrg = Math.Pow(digit1 * digit2 * digit3, (1.0/3));

            Console.WriteLine("Среднее арифметическое введёных чисел равно " + AlgebrAvrg);
            Console.WriteLine("Среднее геометрическое введёных чисел равно " + GeomAvrg);
            Console.ReadKey();
        }
    }
}
