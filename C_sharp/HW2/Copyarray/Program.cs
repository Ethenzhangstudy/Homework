using System;

namespace Copyarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i * 2;
            }

            // copy an array

            int[] copyarray = new int[array.Length];
            for (int j = 0; j < array.Length; j++)
            {
                copyarray[j] = array[j];
            }

        }
    }
}
