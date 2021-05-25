using System;

namespace Insertion
{
    class Program
    {
        static void Main()
        {
            int n = 1024;
            PrintBinary("n", n);

            int m = 19;
            PrintBinary("m", m);

            int i = 2, j = 6;

            int result = Insertion(n, m, i, j);
            PrintBinary("result", result);
            Console.WriteLine("-------------");
            n = 1201;
            PrintBinary("n",n);

            // in Binary M= 10011
            m = 8;
            PrintBinary("m",m);
            i = 3; j = 6;
            result = Insertion(n, m, i, j);
            PrintBinary("result",result);
        }

        public static int Insertion(int n, int m, int i, int j)
        {
            int valueAfterShift = m << i;
            int mask = FormatTheMast(i, j);
            return (n & mask) | valueAfterShift;
        }

        public static int FormatTheMast(int i, int j)
        {
            int allOnes = ~0;
            int left = allOnes << (j + 1);
            int right = ((1 << i) - 1);
            int mask = left | right;
            return mask;
        }

        public static void PrintBinary(string name,int number)
        {
            string binary = Convert.ToString(number, 2);
            Console.WriteLine(name +" : "+number + " in binary -> " + binary);
        }
    }
}
