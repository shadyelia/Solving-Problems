using System;
using System.Collections.Generic;

namespace Permutations
{
    class Program
    {
        static void Main2()
        {
            string input = "aabbbbc";
            List<string> result = GetPerm(input);
            PrintResult(result);
        }

        public static List<string> GetPerm(string input)
        {
            Dictionary<char, int> map = BuildCharactersMap(input);
            List<string> result = new List<string>();
            GetPerm(map, "", input.Length, result);

            return result;
        }

        private static void GetPerm(Dictionary<char, int> map, string prefix, int length, List<string> result)
        {
            if(length == 0)
            {
                result.Add(prefix);
                return;
            }
            foreach(var c in map.Keys)
            {
                int count = map[c];
                if (count > 0)
                {
                    map[c] = count - 1;
                    GetPerm(map, prefix + c, length - 1, result);
                    map[c] = count;
                }
            }
        }

        private static Dictionary<char, int> BuildCharactersMap(string input)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach(char c in input)
            {
                if (map.ContainsKey(c))
                {
                    map[c] = map[c] + 1;
                }
                else
                {
                    map.Add(c, 1);
                }
            }
            return map;
        }

        public static void PrintResult(List<string> result)
        {
            foreach(var s in result)
            {
                Console.WriteLine(s);
            }
        }

    }
}
