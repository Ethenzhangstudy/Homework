using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input the nth Fibonacci number");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(NFibonacci(n));
        }

        static int NFibonacci(int n)
        {
            int a = 0, b = 1;
            for (int i = 2; i < n; i++)
            {
                int c = a + b;
                a = b;
                b = c;
            }
            return a + b;
        }
    }
}
