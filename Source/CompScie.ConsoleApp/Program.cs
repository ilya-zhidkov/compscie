using System;

using CompScie.Core;

namespace CompScie.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();

            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);

            foreach (var node in list)
                Console.Write($"{node} ");
        }
    }
}
