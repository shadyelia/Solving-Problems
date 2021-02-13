using System;
using System.Collections;

namespace One_Away
{
    class Program
    {
        static void Main()
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();

            Solution1(s1, s2);

        }

        static void Solution1(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) >= 2)
            {
                Console.WriteLine("False");
                return;
            }

            Hashtable s2Hashed = new Hashtable();
            foreach (char chara in s2)
            {
                if (s2Hashed.Contains(chara)) s2Hashed[chara] = (int)s2Hashed[chara] + 1;
                else s2Hashed.Add(chara, 1);
            }
            bool isFirstEdit = true;
            foreach (char chara in s1)
            {
                if (s2Hashed.Contains(chara) && (int)s2Hashed[chara] > 0)
                {
                    s2Hashed[chara] = (int)s2Hashed[chara] - 1;
                }
                else
                {
                    if (!isFirstEdit)
                    {
                        Console.WriteLine("False");
                        return;
                    }
                    else isFirstEdit = false;
                }
            }
            Console.WriteLine("True");

        }


        static void Solution2(string s1,string s2)
        {

            // Find lengths of given strings 
            int m = s1.Length, n = s2.Length;

            // If difference between lengths is  
            // more than 1, then strings can't  
            // be at one distance 
            if (Math.Abs(m - n) > 1)
                Console.WriteLine("False");

            // Count of edits 
            int count = 0;
            int i = 0, j = 0;

            while (i < m && j < n)
            {
                // If current characters  
                // don't match 
                if (s1[i] != s2[j])
                {
                    if (count > 1)
                        Console.WriteLine("False");

                    // If length of one string is 
                    // more, then only possible edit 
                    // is to remove a character 
                    if (m > n)
                        i++;
                    else if (m < n)
                        j++;

                    // If lengths of both  
                    // strings is same 
                    else
                    {
                        i++;
                        j++;
                    }

                    // Increment count of edits  
                    count++;
                }

                // If current characters match 
                else
                {
                    i++;
                    j++;
                }
            }

            // If last character is extra  
            // in any string 
            if (i < m || j < n)
                count++;

            if(count <= 1) Console.WriteLine("True");
            else Console.WriteLine("False");
        }

    }
}
