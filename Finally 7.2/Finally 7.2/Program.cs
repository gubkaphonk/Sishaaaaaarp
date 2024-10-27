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
            Console.WriteLine("Введите значение x");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение y");
            int y = int.Parse(Console.ReadLine());
            Console.WriteLine("Результат выражения: " + logic(x, y));
            Console.ReadKey();
        }
        static bool logic(int x, int y)
        {
            if ((y >= 1 || y <= -3) == true)
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
