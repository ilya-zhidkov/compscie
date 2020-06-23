using System;

using CompScie.Core;

namespace CompScie.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree();
            tree.Insert(7);
            tree.Insert(4);
            tree.Insert(4);
            tree.Insert(9);
            tree.Insert(1);
            tree.Insert(6);
            tree.Insert(8);
            tree.Insert(10);

            Console.WriteLine("Pre-order");
            tree.TraversePreOrder();

            Console.WriteLine("\n\nDelete 9");
            tree.Remove(9);

            Console.WriteLine("\nPre-order");
            tree.TraversePreOrder();

            Console.WriteLine();
        }
    }
}
