using System;

namespace Triple_Step
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("N = 4 -> answer from FAP  : " + FindeAPath(4));
            Console.WriteLine("N = 4 -> answer from FAP  : " + FindeAPath2(4));
        }

        static int FindeAPath(int n)
        {
            int[] res = new int[n + 2];
            res[0] = 1;
            res[1] = 1;
            res[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                res[i] = res[i - 1] + res[i - 2] + res[i - 3];
            }
            return res[n];
        }
        static int FindeAPath2(int n)
        {
            if (n < 0) { return 0; }
            if (n <= 1) { return 1; }
            int[] res = { 1, 1, 2 };
            for (int i = 3; i <= n; i++)
            {
                int count = res[0] + res[1] + res[2];
                res[0] = res[1];
                res[1] = res[2];
                res[2] = count;
            }
            return res[2];
        }
    }
}
