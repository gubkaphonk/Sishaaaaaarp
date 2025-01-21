using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Exam_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            Console.WriteLine("Введите чётное число, которое больше либо равно 4");
            i = int.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                var result = ShowPrimeSummands(i);
                if (result != null)
                {
                    Console.WriteLine($"Простые слагаемые для " + i + ":" + result[0] + "+" + result[1]);
                }
                else { Console.WriteLine("Эммм...... Обычно такого не должно происходить......\nВидимо я ошибся в коде :("); }
            }
            else 
            {
                Console.WriteLine("Вы ввели не соответствующее условиям число.\nБольше так не делайте!");
            }
            Console.ReadKey();

        }
        static bool IsItSimpleNumber(int n) //Проверяю является ли n простым числом
        {
            if (n < 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static int[] ShowPrimeSummands(int n)
        {
            for (int i1 = 2; i1 <= n / 2; i1++)
            {
                if (IsItSimpleNumber(i1)==true)
                {
                    if (IsItSimpleNumber(n - i1)==true) 
                    {
                        return new int[] { i1, n - i1 };
                    } 

                }
               
            }
            return null;
            
           
        }
    }
}