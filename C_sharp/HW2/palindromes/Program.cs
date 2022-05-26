using System;
using System.Collections.Generic;

namespace palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input sentence:");
            string[] strnums = Console.ReadLine().Split(' ');
            List<string> array = new List<string>();
            foreach (string num in strnums)
            {
                if (num != "" && IsPalindrome(num))
                {
                    array.Add(num);
                }
            }
            for (int i = 0; i < array.Count; i++)
            {
                Console.Write(array[i]);
                Console.Write(", ");
            }
        }
        static bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;

            int head = 0;
            int tail = s.Length - 1;

            while (head <= tail)
            {

                if (!IsWord(s[head]))
                {
                    head++;
                    continue;
                }
                if (!IsWord(s[tail]))
                {
                    tail--;
                    continue;
                }
                char h = s[head];
                char t = s[tail];
                if (h != t)
                {
                    if (IsNumber(h) || IsNumber(t))
                        return false;
                    if (Math.Abs(h - t) != 32)
                        return false;

                }

                head++;
                tail--;
            }

            return true;
        }

        static bool IsNumber(char a)
        {
            return a >= '0' && a <= '9';
        }

        static bool IsWord(char a)
        {
            return
            (a >= 'a' && a <= 'z') || (a >= 'A' && a <= 'Z') || IsNumber(a);
        }
    }
}
