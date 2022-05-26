using System;

namespace Print_a_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of rows:");
            int rows = int.Parse(Console.ReadLine());
            for (int i = 1; i <= rows; i ++)
            {
                for (int j = rows; j > i; j--)
                {
                    Console.Write(" ");
                }

                for (int k = 0; k < 2 * i - 1; k++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }

        }
    }
}
