using System;

namespace greeting
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime localDate = DateTime.Now;
            int hour = localDate.Hour;
            Console.WriteLine("hour" + hour);
            if (hour <= 5 || hour > 22) { Console.WriteLine("Good Night"); }
            if (hour > 5 && hour <= 12) { Console.WriteLine("Good Morning"); }
            if (hour > 12 && hour <= 18) { Console.WriteLine("Good Afternoon"); }
            if (hour > 18 && hour <= 22) { Console.WriteLine("Good Evening"); }
        }
    }
}
