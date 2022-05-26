using System;

namespace countingnumber
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int j = 1; j <= 4; j++) {
                print_list(j);
            }
        }

        static void print_list(int diff)
        {
            Console.WriteLine(" ");
            int i = 0;
            while (i <= 24)
            {
                Console.Write(i);
                if (i != 24){Console.Write(",");}
                i += diff;
            }
        }
    }
}
