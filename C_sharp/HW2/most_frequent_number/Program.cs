using System;
using System.Collections.Generic;
using System.Linq;

namespace most_frequent_number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input nums:");
            string[] strnums = Console.ReadLine().Split(' ');
            List<int> array = new List<int>();
            foreach(string num in strnums)
            {
                if (num != "")
                {
                    array.Add(Convert.ToInt32(num));
                }
            }
            int[] nums = new int[array.Count];
            for (int i = 0; i < array.Count; i++)
            {
                nums[i] = array[i];
            }

            int[] ans = TopKFrequent(nums, 1);

            foreach(int ele in ans) {
                Console.Write(ele);
                Console.Write(" ");
            }
        }
        static int[] TopKFrequent(int[] nums, int k)
        {
            int[] res = new int[k];
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var value = dic.GetValueOrDefault(nums[i], 0);
                dic[nums[i]] = value + 1;
            }
            List<KeyValuePair<int, int>> h = dic.OrderByDescending(a => a.Value).ToList();
            for (int i = 0; i < k; i++)
            {
                res[i] = h[i].Key;
            }
            return res;
        }
    }
}
