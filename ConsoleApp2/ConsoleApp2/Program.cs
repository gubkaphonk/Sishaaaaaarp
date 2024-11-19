using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение m");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение n");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Результат выражения: " + logic(m, n));
            Console.ReadKey();
        }
        static bool logic(int m,int n)
        {
            if ((m * n) % 5 == 0 && (m + n) % 5 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
