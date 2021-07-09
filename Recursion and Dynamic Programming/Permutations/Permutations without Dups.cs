
using System;
using System.Collections.Generic;

namespace Permutations
{
    class Permutations_without_Dups
    {

        static void Main()
        {
            string input = "abc";
            List<string> result = GetPerm(input);
            PrintResult(result);
        }

        public static List<string> GetPerm(string input)
        {
            int len = input.Length;
            List<string> result = new List<string>();
            List<string> prems = new List<string>();

            if (len == 0)
            {
                result.Add("");
                return result;
            }

            string first = input[0].ToString();
            string remainder = input.Substring(1);
            result = GetPerm(remainder);

            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j <= result[i].Length; j++)
                {
                    var s = result[i].Insert(j, first);
                    prems.Add(s);
                }
            }
            return prems;
        }

        public static void PrintResult(List<string> result)
        {
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }

    }
}
