using System;

namespace URLify
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(',');
            if (input.Length == 2)
                Solution1(input[0], Convert.ToInt32(input[1]));
            else Console.Write("Wrong input");
        }

        static void Solution1(string s1, int reallyLength)
        {
            int startCouting = 0;
            for (int i = 0; startCouting < reallyLength; i++)
            {
                if (s1[i] != '"')
                {
                    if (startCouting == 0 && s1[i] == ' ')
                        continue;

                    if (startCouting > 0 && s1[i] == ' ')
                        Console.Write("%20");
                    else
                        Console.Write(s1[i]);

                    startCouting++;
                }
            }
        }

        static void Solution2(string s1, int reallyLength)
        {
            s1 = s1.Replace("\"", "").Trim();
            Console.WriteLine(s1.Replace(" ", "%20"));
        }
    }
}
