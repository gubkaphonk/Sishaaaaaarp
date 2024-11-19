using System;

namespace Chess7._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[8, 8];



            Console.WriteLine("Введите индекс позиции на которую вы хотите поставить белую фигуру:");
            string whiteFigIndx = Console.ReadLine();
            int whtePosition = indexToInteger(whiteFigIndx);

            if (whtePosition != -1)
            {
                indexToCoord(whtePosition, out int x, out int y);
                SetAttackingZones(matrix, x, y);
                Console.WriteLine($"Фигура поставлена на позицию {whiteFigIndx}.");
            }
            //showMatrix(matrix);


            Console.WriteLine("Введите индекс позиции на которую вы хотите поставить черную фигуру:");
            string blackFigIndx = Console.ReadLine();
            int blckPosition = indexToInteger(blackFigIndx);

            if (blckPosition != -1)
            {
                indexToCoord(whtePosition, out int x, out int y);
                SetAttackingZones(matrix, x, y);
                Console.WriteLine($"Фигура поставлена на позицию {blackFigIndx}.");
            }



            //showMatrix(matrix);
            if (checkPositions(matrix) == true)
            {



                Console.WriteLine("Введите индекс позиции на которую вы хотите передвинуть белую фигуру:");
                string newWhtIndx = Console.ReadLine();
                int newWhtPos = indexToInteger(newWhtIndx);

                if (newWhtPos != -1)
                {
                    int x = newWhtPos / 10;
                    int y = newWhtPos % 10;
                    if (doesPositionAveilible(matrix, x, y) == true)
                    {
                        Console.WriteLine("Этот ход безопасен.");
                    }
                    else
                    {
                        Console.WriteLine("Этот ход невозможен, либо ведёт к потере фигуры.");
                    }
                }
            }


            Console.ReadKey();
        }
        static void showMatrix(int[,] matrix)//Отвечает за вывод матрицы 
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int indexToInteger(string whiteFigIndx)//Преобразует индекс в число
        {
            if (whiteFigIndx.Length == 2)
            {
                int x = replacementList(whiteFigIndx[0]);
                int y = replacementList(whiteFigIndx[1]);

                if (x >= 0 && x < 8 && y >= 0 && y < 8)
                {
                    return x * 10 + y;
                }
                else
                {
                    Console.WriteLine("Индекс вне диапазона.");
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("Индекс введён с ошибкой.");
                return -1;
            }
        }

        static int replacementList(char symbol)//Вспомогательная к indexToInteger
        {
            switch (symbol)
            {
                case 'a': return 0;
                case 'b': return 1;
                case 'c': return 2;
                case 'd': return 3;
                case 'e': return 4;
                case 'f': return 5;
                case 'g': return 6;
                case 'h': return 7;
                case '1': return 0;
                case '2': return 1;
                case '3': return 2;
                case '4': return 3;
                case '5': return 4;
                case '6': return 5;
                case '7': return 6;
                case '8': return 7;
                default: return -1;
            }
        }
        static int[,] SetAttackingZones(int[,] matrix, int x, int y)//Отмечает позиции где стоит фигура и куда может сходить 
        {
            matrix[x, y] = -13;
            for (int x1 = x, y1 = y; (x1 > -1) && (y1 > -1); x1--, y1--)
            {
                matrix[x1, y1] = matrix[x1, y1] + 1;
            }
            for (int x1 = x, y1 = y; (x1 < 8) && (y1 < 8); x1++, y1++)
            {
                matrix[x1, y1] = matrix[x1, y1] + 1;
            }
            for (int x1 = x, y1 = y; (x1 < 8) && (y1 > -1); x1++, y1--)
            {
                matrix[x1, y1] = matrix[x1, y1] + 1;
            }
            for (int x1 = x, y1 = y; (x1 > -1) && (y1 < 8); x1--, y1++)
            {
                matrix[x1, y1] = matrix[x1, y1] + 1;
            }

            for (int x1 = x, y1 = y; (x1 < 8) && (y1 > -1); x1++)
            {
                matrix[x1, y1] = matrix[x1, y1] + 1;
            }
            for (int x1 = x, y1 = y; (x1 < 8) && (y1 < 8); y1++)
            {
                matrix[x1, y1] = matrix[x1, y1] + 1;
            }
            for (int x1 = x, y1 = y; (x1 < 8) && (y1 > -1); y1--)
            {
                matrix[x1, y1] = matrix[x1, y1] + 1;
            }
            for (int x1 = x, y1 = y; (x1 > -1) && (y1 < 8); x1--)
            {
                matrix[x1, y1] = matrix[x1, y1] + 1;
            }
            return matrix;
        }
        static bool checkPositions(int[,] matrix)//Проверяет расстановку фигур
        {
            int mistake = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (matrix[i, j] == -10 || matrix[i, j] == -4)
                    {
                        Console.WriteLine("Нельзя поставить фигуры таким образом.");
                        mistake++;
                    }
                }
                Console.WriteLine();
            }
            if (mistake == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool doesPositionAveilible(int[,] matrix, int x, int y)//Проверяет можно ли сходить белой фигурой туда 
        {
            if (matrix[x, y] != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static int indexToCoord(int whtePosition, out int x, out int y)//Выводит координаты из индекса
        {
            x = whtePosition / 10;
            y = whtePosition % 10;
            return 0;
        }
    }
}