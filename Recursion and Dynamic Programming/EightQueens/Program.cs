using System;
using System.Collections.Generic;

namespace Coins
{
    class Program
    {
        private static int SIZE = 8;
        static void Main()
        {
            List<int[]> result = new List<int[]>();
            int[] col = new int[SIZE];
            SetQueen(result, col, 0);
            PrintList(result);
        }



        public static void SetQueen(List<int[]> result, int[] col, int row)
        {
            if ((row == SIZE))
            {
                result.Add((int[])col.Clone());
                return;
            }

            for (int i = 0; (i < SIZE); i++)
            {
                if (IsAvalible(row, col, i))
                {
                    col[row] = i;
                    SetQueen(result, col, (row + 1));
                }

            }

        }

        public static bool IsAvalible(int row, int[] col, int c)
        {
            for (int i = 0; (i < row); i++)
            {
                if ((col[i] == c))
                {
                    return false;
                }

                if (((row - i)
                            == Math.Abs((col[i] - c))))
                {
                    return false;
                }

            }

            return true;
        }

        public static void PrintList(List<int[]> l)
        {
            for (int i = 0; (i < l.Count); i++)
            {
                for (int j = 0; (j < SIZE); j++)
                {
                    Console.Write(l[i][j]);
                }

                Console.WriteLine("");
            }

        }
    }
}
