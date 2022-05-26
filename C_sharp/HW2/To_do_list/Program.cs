using System;
using System.Collections.Generic;

namespace To_do_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> todolist = new List<string>();
            Console.WriteLine("Enter:");
            string op = Console.ReadLine();
            if(op == "--")
            {
                todolist = new List<string>();
            }
            else
            {
                string[] words = op.Split(' ');
                List<string> op_list = new List<string>();
                foreach (var word in words)
                {
                    op_list.Add(word);
                }
                if (op_list[0] == "+")
                {
                    todolist.Add(op_list[1]);
                }
                else {
                    todolist.Remove(op_list[1]);
               }
            }
        }
    }
}
