using System;
using System.Collections.Generic;

namespace reverses_words
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
                if (num != "")
                {
                    array.Add(num);
                }
            }
            for (int i = 0; i < array.Count; i++) {
                Console.Write(array[array.Count - 1 - i]);
                Console.Write(" ");
            }

        }
    }
}
