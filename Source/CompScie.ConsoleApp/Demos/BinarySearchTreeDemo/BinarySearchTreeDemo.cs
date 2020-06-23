using System;
using System.Collections.Generic;
using System.Linq;

using CompScie.ConsoleApp.Demos.BinarySearchTreeDemo.Operations;
using CompScie.ConsoleApp.Demos.StackDemo.Operations;
using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.BinarySearchTreeDemo
{
    public class BinarySearchTreeDemo
    {
        public static void Show()
        {
            var numbers = Array.ConvertAll(FileUtilities.Read("cisla.txt"), int.Parse);
            var tree = new Tree();

            foreach (var number in numbers)
                tree.Insert(number);

            var operations = new Dictionary<int, IOperation>
            {
                { 1, new FindOperation(tree) },
                { 2, new InsertOperation(tree) },
                { 3, new RemoveOperation(tree) }
            };

            while (true)
            {
                ConsoleUtilities.DisplayMenu(options: new[] { "1. Najit prvek", "2. Pridat prvek", "3. Odebrat prvek" });

                ConsoleUtilities.Prompt("\nZvolte moznost: ");
                var operation = ConsoleUtilities.GetUserInput();

                if (!operations.ContainsKey(operation))
                {
                    ConsoleUtilities.Prompt("\nNespravna volba. Ukonceni aplikace...\n");
                    break;
                }

                operations.Where(o => o.Key == operation).First().Value.Perform();

                ConsoleUtilities.Prompt($"\n{new string('-', 30)}\n");
            }
        }
    }
}
