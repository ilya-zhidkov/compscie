using System;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.StackDemo.Operations
{
    public class PushOperation : IOperation
    {
        private readonly Stack stack;

        public PushOperation(Stack stack) => this.stack = stack;

        public void Perform()
        {
            ConsoleUtilities.Prompt("\nHow many items to push? ");
            var count = ConsoleUtilities.GetUserInput();

            for (var index = 0; index < count; index++)
            {
                try
                {
                    ConsoleUtilities.Prompt($"\nEnter an item to push: ");
                    stack.Push(ConsoleUtilities.GetUserInput());
                    ConsoleUtilities.Prompt($"Stack: {stack}\n");
                }
                catch (StackOverflowException exception)
                {
                    ConsoleUtilities.Prompt($"\nERROR: {exception.Message}\n");
                    break;
                }
            }
        }
    }
}
