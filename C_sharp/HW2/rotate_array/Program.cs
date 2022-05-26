using System;
using System.Collections.Generic;

namespace rotate_array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input nums:");
            string strnums = Console.ReadLine();
            string[] tmp = strnums.Split(" ");
            List<int> nums = new List<int>();
            foreach (string num in tmp){
                nums.Add(Convert.ToInt32(num));
            }
            Console.WriteLine("input k:");
            int k = Convert.ToInt32(Console.ReadLine());
            k = k % nums.Count;
            for (var i = 0; i < k; i++)
            {
                var previous = nums[nums.Count - 1];
                for (var j = 0; j < nums.Count; j++)
                {
                    var temp = nums[j];
                    nums[j] = previous;
                    previous = temp;
                }
            }
            Console.Write("rotated ");
            foreach (int ele in nums)
            {
                Console.Write(ele);
                Console.Write(" ");
            }
        }
    }
}
