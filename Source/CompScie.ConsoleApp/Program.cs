using System;

using CompScie.Core;

namespace CompScie.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable();
            table.Put(6, "a"); // index: 6 % 5 = 1
            table.Put(8, "b"); // index: 8 % 5 = 3
            table.Put(11, "c"); // COLLISION! index: 1 -> add to linked list

            table.Remove(6);

            Console.WriteLine(table.Get(11)); // c

            Console.WriteLine(table); // {11=c, 8=b}
        }
    }
}
