using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число x");
            double x = double.Parse(Console.ReadLine());
            if (x < -2)
            {
                Console.WriteLine(Equation1(x));
            }
            if (x > 1)
            {
                Console.WriteLine(Equation3(x));
            }
            else
            {
                Console.WriteLine(Equation2(x));
            }
            Console.ReadKey();

        }
        static double Equation1(double x)
        {
            return (Math.Pow(Math.Pow(x,2) + 4,0.5)) ;
        }
        static double Equation2(double x)
        {
            return (1/(Math.Pow(x, 2) + 1));
        }
        static double Equation3(double x)
        {
            return (Math.Pow(Math.Pow(x, 2) - 1, 0.5));
        }
    }
}
