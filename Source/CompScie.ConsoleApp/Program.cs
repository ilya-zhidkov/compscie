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

            Console.WriteLine("Before removal:");
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine($"List: {list}");

            list.Remove(20);

            Console.WriteLine("\nAfter removal:");
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine($"List: {list}");
        }
    }
}
