using System;

namespace randomnumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int correctNumber = new Random().Next(3) + 1;
            int guessedNumber = 5;
            Console.WriteLine("ture number is " + correctNumber);
            Console.WriteLine("please guss a number from 1~3:");
            while (guessedNumber != correctNumber)
            {
                guessedNumber = int.Parse(Console.ReadLine());
                if (guessedNumber > correctNumber)
                {
                    Console.WriteLine("too large");
                }
                else if (guessedNumber < correctNumber)
                {
                    Console.WriteLine("too small");
                }
            }
            Console.WriteLine("success");
        }
    }
}
