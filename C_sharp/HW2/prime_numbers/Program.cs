using System;

namespace prime_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input range left");
            int startNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input range right");
            int endNum = Convert.ToInt32(Console.ReadLine());

            for (int i = startNum; i <= endNum; i++)
            {
                if (check(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
        static bool check(int num)
        {
            if (num == 0 || num == 1)
            {
                return false;
            }
            else
            {
                for (int a = 2; a <= num / 2; a++)
                {
                    if (num % a == 0)
                    {
                        return false;
                    }

                }
                return true;
            }
        }
    }
}
