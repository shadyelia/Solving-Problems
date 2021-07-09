using System;
using System.Collections.Generic;
using System.Text;

namespace Parens
{
    class Program
    {
        static void Main()
        {
            int n = 3;
            HashSet<string> result = GetParens(n);
            PrintResult(result);
        }

        private static HashSet<string> GetParens(int n)
        {
            HashSet<string> result = new HashSet<string>();
            HashSet<string> prems = new HashSet<string>();

            if (n == 1) { prems.Add("()"); return prems; }
            result = GetParens(n - 1);

            foreach (string s in result)
            {
                for (int i = 0; i <= s.Length; i++)
                {
                    string addedPren = AddPrenInIndex(s, i);
                    prems.Add(addedPren);
                }
            }


            return prems;
        }

        private static string AddPrenInIndex(string s, int index)
        {
            StringBuilder sb = new StringBuilder();
            Stack<char> charas = new Stack<char>();
            bool addedBefore = false;
            int len = s.Length;
            
            for (int i = 0; i <= len; i++)
            {
                if (i == index)
                {
                    sb.Append('(');
                }
                if (i < len)
                {
                    sb.Append(s[i]);
                }

                if (i < len && s[i] == '(')
                {
                    charas.Push(s[i]);
                }
                else if(charas.Count >= 1) { charas.Pop(); }

                if(i >= index && charas.Count == 0 && !addedBefore)
                {
                    sb.Append(')');
                    addedBefore = true;
                }
            }

            return sb.ToString();
        }

        public static void PrintResult(HashSet<string> result)
        {
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}
