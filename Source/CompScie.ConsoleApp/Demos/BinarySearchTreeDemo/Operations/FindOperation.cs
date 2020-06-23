using System;

using CompScie.ConsoleApp.Demos.StackDemo.Operations;
using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.BinarySearchTreeDemo.Operations
{
    public class FindOperation : IOperation
    {
        private readonly Tree tree;

        public FindOperation(Tree tree) => this.tree = tree;

        public void Perform()
        {
            try
            {
                ConsoleUtilities.Prompt($"\nZadejte hodnotu: ");
                ConsoleUtilities.Prompt($"{(tree.Find(ConsoleUtilities.GetUserInput()) ? "\nNalezeno\n" : "\nNenalezeno\n")}");
            }
            catch (Exception exception)
            {
                ConsoleUtilities.Prompt($"\nCHYBA: {exception.Message}\n");
                return;
            }
        }
    }
}
