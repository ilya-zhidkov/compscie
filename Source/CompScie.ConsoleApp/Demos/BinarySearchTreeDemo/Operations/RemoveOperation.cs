using System;

using CompScie.ConsoleApp.Demos.StackDemo.Operations;
using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.BinarySearchTreeDemo.Operations
{
    public class RemoveOperation : IOperation
    {
        private readonly Tree tree;

        public RemoveOperation(Tree tree) => this.tree = tree;

        public void Perform()
        {
            try
            {
                ConsoleUtilities.Prompt($"\nZadejte hodnotu: ");
                tree.Remove(ConsoleUtilities.GetUserInput());
                ConsoleUtilities.Prompt("\n");
                tree.TraversePreOrder();
                ConsoleUtilities.Prompt("\n");
            }
            catch (Exception exception)
            {
                ConsoleUtilities.Prompt($"\nCHYBA: {exception.Message}\n");
                return;
            }
        }
    }
}
