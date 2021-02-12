using System;
using System.Collections.Generic;

namespace Check_Permutation
{
    class Program
    {
        static void Main()
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            int n1 = s1.Length;
            int n2 = s2.Length;

            // If length of both strings is not same, 
            // then they cannot be Permutation 
            if (n1 != n2)
            {
                Console.WriteLine("NO");
                return;
            }

            Solution1(s1, s2);
        }
        /*
         * save first string in hash table then check with second one
         * o(n)
        */
        static void Solution1(string s1, string s2)
        {
            HashSet<char> charachersS1 = new HashSet<char>();
            foreach (var chara in s1)
            {
                charachersS1.Add(chara);
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (!charachersS1.Contains(s2[i]))
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }

        /*
         * sort two strings and then compare 
         * O(n^2) quick sort 
         * O(n log n) merge sort
         */
        static void Solution2(string s1, string s2)
        {
            char[] ch1 = s1.ToCharArray();
            char[] ch2 = s2.ToCharArray();

            // Sort both strings 
            Array.Sort(ch1);
            Array.Sort(ch2);

            // Compare sorted strings 
            for (int i = 0; i < s1.Length; i++)
                if (ch1[i] != ch2[i])
                    Console.WriteLine("NO");

            Console.WriteLine("YES");
        }

        /*
         * create array size of characters, ++ for s1 
         * -- for s2 and check that all count[character] = 0
         * O(n)
         */
        static void Solution3(string s1, string s2)
        {
            const int NO_OF_CHARS = 256;

            int[] count = new int[NO_OF_CHARS];

            for (var i = 0; i < s1.Length; i++)
            {
                count[s1[i]]++;
                count[s2[i]]--;
            }


            // See if there is any non-zero value in  
            // count array 
            for (var i = 0; i < NO_OF_CHARS; i++)
                if (count[i] != 0)
                    Console.WriteLine("NO");
            Console.WriteLine("YES");
        }

    }
}
