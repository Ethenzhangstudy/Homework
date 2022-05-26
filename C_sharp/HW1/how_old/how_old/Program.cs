using System;

namespace how_old
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter the birthday like : Jan 1, 2009");
            string dateInput = Console.ReadLine();
            var parsedDate = DateTime.Parse(dateInput);
            DateTime localDate = DateTime.Now;
            Console.WriteLine("old days are {0}", (localDate - parsedDate).TotalDays);
            // age = DateTime.Now.Day – DateTime.Parse(dateInput).Day;
            //if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            //    age = age – 1;
        }
    }
}
