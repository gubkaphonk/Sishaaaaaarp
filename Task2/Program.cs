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
            /* double angleInDegrees = 15;
            double dngleInRadians = angleInDegrees*Math.PI/100;
            double sin = Math.Sin(angle);
            double cos Math.Cos(angle);

            Console.WriteLine("sin(15°) = " + Math.Round(sin, 3));

            Console.WriteLine("cos(15°) = " + Math.Round(cos, 3));

            Console.WriteLine();
            Console.WriteLine("Введите значение угла в градусах.");
            angleInDegrees=double.Parse(Console.ReadLine());

            Console.ReadKey();*/
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
