using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var y = (sinSum(2, 3) / cosSum(2, 3)) + (cosSum(5, 7) / sinSum(5, 7));
            Console.WriteLine("x = " + y);
            Console.ReadKey();
        }

        static double sinSum(double a, double b)
        {
            double y = Math.Sin(a) + Math.Sin(b);
            return y;
        }
        static double cosSum(double a, double b)
        {
            double y = Math.Cos(a) + Math.Cos(b);
            return y;
        }
    }
}
