using System;
using System.Collections.Generic;

namespace longest_equal_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input nums");
            string[] strnums = Console.ReadLine().Split(' ');
            List<int> nums = new List<int>();
            foreach (string num in strnums)
            {
                if (num != "")
                {
                    nums.Add(Convert.ToInt32(num));
                }
            }
            int N = nums.Count;
            int key = nums[0];
            int h = 0;
            int length = 1;
            for (int t = 1; t < N; t++) {
                while (t < N && nums[t] == nums[t - 1])
                {
                    t++;
                }
                if (t < N && t - h > length) {
                    length = t - h;
                    key = nums[t - 1];
                    h = t;
                    t++;
                }
                else {
                    h = t;
                    t++;
                }
            }

            for (int i = 0; i < length; i++){
                Console.Write(key);
                Console.Write(" ");
            }
        }
    }
}
