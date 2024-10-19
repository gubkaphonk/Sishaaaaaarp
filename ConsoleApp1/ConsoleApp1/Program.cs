using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текстовое сообщение");
            var message = Console.ReadLine();
            string[] symbols = SplitStringToArray(message);

            for (int i = 0; i < symbols.Length; i++)
            {
                symbols[i] = perevodik(symbols[i][0]); 
            }
            Console.WriteLine(String.Concat(symbols));
            Console.ReadKey();
        }

        static string[] SplitStringToArray(string input)
        {
            string[] stringArray = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                stringArray[i] = input[i].ToString();
            }

            return stringArray;
        }

        static string perevodik(char znak)
        {
            switch (znak)
            {
                case 'А':
                    return "A";
                case 'Б':
                    return "B";
                case 'В':
                    return "V";
                case 'Г':
                    return "G";
                case 'Д':
                    return "D";
                case 'Е':
                    return "E";
                case 'Ё':
                    return "E";
                case 'Ж':
                    return "ZH";
                case 'З':
                    return "Z";
                case 'И':
                    return "I";
                case 'Й':
                    return "I";
                case 'К':
                    return "K";
                case 'Л':
                    return "L";
                case 'М': 
                    return "M";
                case 'Н':
                    return "N";
                case 'О':
                    return "O";
                case 'Р':
                    return "R";
                case 'П':
                    return "P";
                case 'С':
                    return "S";
                case 'Т':
                    return "T";
                case 'У':
                    return "U";
                case 'Ф':
                    return "F";
                case 'Х':
                    return "KH";
                case 'Ц':
                    return "TS";
                case 'Ч':
                    return "CH";
                case 'Ш':
                    return "SH";
                case 'Щ':
                    return "SHCH";
                case 'Ъ': 
                    return "IE";
                case 'Ы':
                    return "Y";
                case 'Ь':
                    return "";
                case 'Э':
                    return "E";
                case 'Ю':
                    return "IU";
                case 'Я':
                    return "IA";

                default:
                    return znak.ToString(); 
            }
        }
    }
}