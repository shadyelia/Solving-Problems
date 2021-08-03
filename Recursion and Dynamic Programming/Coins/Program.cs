using System;

namespace Coins
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(MakeChange(100));
        }
        static int MakeChange(int n)
        {
            int[] denoms = new int[] {
                25,
                10,
                5,
                1};
            int[,] map = new int[n + 1, denoms.Length];
            return MakeChange(n, denoms, 0, map);
        }

        static int MakeChange(int amount, int[] denoms, int index, int[,] map)
        {
            if (map[amount, index] > 0)
            {
                return map[amount, index];
            }

            if (index >= (denoms.Length - 1))
            {
                return 1;
            }

            int denomAmount = denoms[index];
            int ways = 0;
            for (int i = 0; (i * denomAmount) <= amount; i++)
            {
                int amountRemaining = amount - (i * denomAmount);
                ways = ways + MakeChange(amountRemaining, denoms, index + 1, map);
            }

            map[amount, index] = ways;
            return ways;
        }
    }
}
