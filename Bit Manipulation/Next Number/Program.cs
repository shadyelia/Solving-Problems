using System;
using System.Text;

namespace Next_Number
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("------ number 5-----------");
            GetNextNumbers(5);
            Console.WriteLine("------ number 8-----------");
            GetNextNumbers(8);
        }

        public static void GetNextNumbers(int number)
        {
            string numberInBinary = ConvertToBinary(number);
            StringBuilder nextNumberInBinary = new StringBuilder(numberInBinary);
            bool isOneFlipped = false; int length = numberInBinary.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                if (numberInBinary[i] == '1' && !isOneFlipped)
                {
                    nextNumberInBinary[i] = '0';
                    isOneFlipped = true;
                    if (i == 0)
                    {
                        nextNumberInBinary.Insert(0, '1');
                    }
                }
                if (numberInBinary[i] == '0' && isOneFlipped)
                {
                    nextNumberInBinary[i] = '1';
                    break;
                }
            }
            Console.WriteLine("The next greatest  number : " + ConvertToInt(nextNumberInBinary) +" and binary => "+ nextNumberInBinary);
            
            nextNumberInBinary = new StringBuilder(numberInBinary);
            isOneFlipped = false;
            for (int i = 0; i < length ; i++)
            {
                if (numberInBinary[i] == '1' && !isOneFlipped)
                {
                    nextNumberInBinary[i] = '0';
                    isOneFlipped = true;
                }
                if (numberInBinary[i] == '0' && isOneFlipped)
                {
                    nextNumberInBinary[i] = '1';
                    break;
                }
            }
            Console.WriteLine("The next smallest number : " + ConvertToInt(nextNumberInBinary) + " and binary => " + nextNumberInBinary);
        }

        private static string ConvertToBinary(int number)
        {
            return Convert.ToString(number, 2);
        }
        private static int ConvertToInt(StringBuilder number)
        {
            return Convert.ToInt32(number.ToString(), 2);
        }
    }
}
