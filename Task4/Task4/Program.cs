using System;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение x");
            var ics = double.Parse(Console.ReadLine());
            var y = calculation(ics);
            Console.WriteLine("f(x) = " + y);
            Console.ReadKey();
        }

        static double calculation(double x)
        {
            double y = 2 * Math.Sin(Math.Pow(Math.Pow(x,2) + 4, 0.5) / 2) * Math.Cos(Math.Pow(Math.Pow(x, 2) + 1, 0.5) / 2);
            return y;
        }
    }
}
