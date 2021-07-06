using System;
using System.Diagnostics;
using System.Linq;

namespace LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Stopwatch stopwatch = Stopwatch.StartNew();

            int result = LengthOfLongestSubstring("abcabcbb");

            long milliseconds = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Result is {result}, expecting is 3, Runtime : {milliseconds} ms");
        }



        public static int LengthOfLongestSubstring(string s)
        {

            int n = s.Count();

            int res = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (Check(s, i, j)) res = Math.Max(res, j - i + 1);
                }
            }

            return res;

        }

        private static bool Check(string s, int start, int end)
        {
            int[] chars = new int[128];

            for (int i = start; i <= end; i++)
            {
                char c = s[i];
                chars[c]++;
                if (chars[c] > 1) return false;
            }

            return true;
        }

    }
}
