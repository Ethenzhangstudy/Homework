using System;
namespace UnderstandingTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("size of sbyte        : {0}", sizeof(sbyte));
            Console.WriteLine("MaxValue of sbyte    : {0}", sbyte.MaxValue);
            Console.WriteLine("MinValue of sbyte    : {0}", sbyte.MinValue);

            Console.WriteLine("size of  byte        : {0}", sizeof(byte));
            Console.WriteLine("MaxValue of  byte    : {0}", byte.MaxValue);
            Console.WriteLine("MinValue of  byte    : {0}", byte.MinValue);

            Console.WriteLine("size of short        : {0}", sizeof(short));
            Console.WriteLine("MaxValue of short    : {0}", short.MaxValue);
            Console.WriteLine("MinValue of short    : {0}", short.MinValue);

            Console.WriteLine("size of ushort       : {0}", sizeof(ushort));
            Console.WriteLine("MaxValue of ushort   : {0}", ushort.MaxValue);
            Console.WriteLine("MinValue of ushort   : {0}", ushort.MinValue);

            Console.WriteLine("size of int          : {0}", sizeof(int));
            Console.WriteLine("MaxValue of int      : {0}", int.MaxValue);
            Console.WriteLine("MinValue of int      : {0}", int.MinValue);

            Console.WriteLine("size of uint         : {0}", sizeof(uint));
            Console.WriteLine("MaxValue of uint     : {0}", uint.MaxValue);
            Console.WriteLine("MinValue of uint     : {0}", uint.MinValue);

            Console.WriteLine("size of long         : {0}", sizeof(long));
            Console.WriteLine("MaxValue of long     : {0}", long.MaxValue);
            Console.WriteLine("MinValue of long     : {0}", long.MinValue);

            Console.WriteLine("size of ulong        : {0}", sizeof(ulong));
            Console.WriteLine("MaxValue of ulong    : {0}", ulong.MaxValue);
            Console.WriteLine("MinValue of ulong    : {0}", ulong.MinValue);

            Console.WriteLine("size of float        : {0}", sizeof(float));
            Console.WriteLine("MaxValue of float    : {0}", float.MaxValue);
            Console.WriteLine("MinValue of float    : {0}", float.MinValue);

            Console.WriteLine("size of double       : {0}", sizeof(double));
            Console.WriteLine("MaxValue of double   : {0}", double.MaxValue);
            Console.WriteLine("MinValue of double   : {0}", double.MinValue);

            Console.WriteLine("size of decimal      : {0}", sizeof(decimal));
            Console.WriteLine("MaxValue of decimal  : {0}", decimal.MaxValue);
            Console.WriteLine("MinValue of decimal  : {0}", decimal.MinValue);

            Console.WriteLine("Enter number of centuries:");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = 100 * a;
            long c = 36524 * a;
            long d = 876576 * a;
            long e = 52594560 * a;
            long f = 3155673600 * a;
            float g = 3155673600000 * a;
            float h = 3155673600000000 * a;
            double i = 3155673600000000000 * a;
            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds", a, b,c,d,e,f,g,h,i);
        }


    }
}
