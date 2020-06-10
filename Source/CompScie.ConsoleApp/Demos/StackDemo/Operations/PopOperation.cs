using System;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.StackDemo.Operations
{
    public class PopOperation : IOperation
    {
        private readonly Stack stack;

        public PopOperation(Stack stack) => this.stack = stack;

        public void Perform()
        {
            ConsoleUtilities.Prompt("\nHow many items to pop? ");
            var count = ConsoleUtilities.GetUserInput();

            for (var index = 0; index < count; index++)
            {
                try
                {
                    ConsoleUtilities.Prompt($"Popped: {stack.Pop()}\n");
                }
                catch (InvalidOperationException exception)
                {
                    ConsoleUtilities.Prompt($"\nERROR: {exception.Message}\n");
                    break;
                }
            }

            ConsoleUtilities.Prompt($"\nStack: {stack}\n");
        }
    }
}
