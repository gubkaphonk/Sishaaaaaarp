using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите четырёхзначное число n");
            string n = Console.ReadLine();
            char[] symbol = n.ToCharArray();
            string x = string.Concat(symbol[0], symbol[3], symbol[1], symbol[2]);
            Console.WriteLine(x);
            Console.ReadKey();

        }
    }
}