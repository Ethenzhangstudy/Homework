using System;
using System.Collections.Generic;

namespace reverses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input a string");
            string s = Console.ReadLine();
            int n = s.Length;
            char[] arr = s.ToCharArray();
            char[] ans = new char[n];
            for (int i = 0; i < n; i += 1)
            {
                ans[i] = arr[n - 1 - i];
            }
            Console.Write(ans);
        }
    }
}
