using System;

namespace Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = GenerateNumbers();
            Reverse(numbers);
            PrintNumbers(numbers);

        }
        static int[] GenerateNumbers()
        {
            System.Random random = new System.Random();
            int[] res = new int[10];
            for (int i = 0; i < 10; i++)
            {
                res[i] = random.Next(20);
            }

            return res;
        }

        static void Reverse(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n / 2; i++)
            {
                int tmp = nums[i];
                nums[i] = nums[n - i - 1];
                nums[n - i - 1] = tmp;
            }
        }

        static void PrintNumbers(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i]);
                Console.Write(" ");
            }
        }
    }
}
