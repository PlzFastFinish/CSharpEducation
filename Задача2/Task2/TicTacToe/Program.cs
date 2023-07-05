
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace TicTacToe
{
    internal class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', };
        static int player = 1;
        static int choice = 1;
        static int flag = 0;
        static void Main(string[] args)

        {
            do
            {
                Console.Clear();
                Console.WriteLine("Игрок 1: X Игрок 2: О");
                Console.WriteLine("\n");

                if (player % 2 == 0)
                {
                    Console.WriteLine("Ход игрока 2");
                }
                else
                {
                    Console.WriteLine("Ход игрока 1");
                }

                Console.WriteLine("\n");
                Board();
                choice = int.Parse(Console.ReadLine());

                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Клетка {0} уже занята {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Выберете другую клетку");
                    Thread.Sleep(1500);
                }
                flag = CheckWin();

            }
            while (flag != 1 & flag != -1);

            Console.Clear();

            Board();

            if (flag == 1)
            {
                Console.WriteLine("Игрок {0} победил!!", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Ничья");
            }
            Console.ReadLine();
        }

        private static void Board()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |     ");
        }

        private static int CheckWin()
        {
            #region Проверка победы по горизонтали
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Проверка победы по вертикали
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion

            #region Проверка победы по диагонали

            else if(arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion

            #region Проверка на ничью
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9') 
            { 
                return -1; 
            }
            #endregion
            else 
            { 
                return 0; 
            }
        }


    }
}