using System;

using CompScie.Core;

namespace CompScie.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            Console.WriteLine(list);
        }
    }
}
