using System;
using System.Collections.Generic;

namespace Is_Unique
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            soluiton1(input);

        }

        /*
         * with hashset of characters
         */
        static void soluiton1(string input)
        {
            HashSet<char> characters = new HashSet<char>();
            foreach (char chara in input)
            {
                if (characters.Contains(chara))
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                    characters.Add(chara);
                }
            }

            Console.WriteLine("YES");
        }

        /*
         * with array of bools
         */
        static void soluiton2(string input)
        {
            const int _maxCharacters = 256;
            bool[] characters = new bool[_maxCharacters];
            foreach (char chara in input)
            {

                if (characters[Convert.ToInt32(chara)] == true)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                    characters[Convert.ToInt32(chara)] = true;
                }
            }

            Console.WriteLine("YES");
        }

        /*
         * without extra data structure
         */
        static void solution3(string input)
        {
            // Assuming string can have
            // characters a-z this has
            // 32 bits set to 0 -> int
            // 64 bits set to 0 -> long (a-z and more)
            int checker = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int bitAtIndex = input[i] - 'a'; //finding index of char like in hash table after hashing the key

                // if that bit is already set
                // in checker, print No
                if ((checker & (1 << bitAtIndex)) > 0)
                {
                    Console.WriteLine("NO");
                    return;
                }

                // otherwise update and continue by
                // setting that bit in the checker
                checker |= (1 << bitAtIndex);
            }

            // no duplicates encountered,
            // return Yes
            Console.WriteLine("YES");

        }
    }
}
