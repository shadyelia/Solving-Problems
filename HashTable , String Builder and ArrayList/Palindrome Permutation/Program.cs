using System;
using System.Collections;
using System.Collections.Generic;

namespace Palindrome_Permutation
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Solution1(input);
        }

        /*
         * create hashtable from the string and put every chara in the hash
         * check if found more than one odd print no
         * else print yes
         * O(n)
         */
        static void Solution1(string input)
        {
            Hashtable data = new Hashtable();
            foreach (char chara in input)
            {
                if (!data.Contains(chara)) data.Add(chara, 1);
                else data[chara]=(int)data[chara] + 1;
            }
            bool firstOdd = true;
            foreach (char chara in input)
            {
                if((int)data[chara]%2 != 0)
                {
                    if (firstOdd) firstOdd = false;
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }

        static void Solution2(string str)
        {
            // Create a list
            List<char> list = new List<char>();

            // For each character in input strings,
            // remove character if list contains
            // else add character to list
            for (int i = 0; i < str.Length; i++)
            {
                if (list.Contains(str[i]))
                    list.Remove((char)str[i]);
                else
                    list.Add(str[i]);
            }

            // if character length is even
            // list is expected to be empty
            // or if character length is odd
            // list size is expected to be 1

            // if string length is even
            if (str.Length % 2 == 0 && list.Count == 0
                ||
                (str.Length % 2 == 1
                 && list.Count == 1))
                Console.WriteLine("YES");


            // if string length is odd
            else
                Console.WriteLine("NO");
        }
    }
}
