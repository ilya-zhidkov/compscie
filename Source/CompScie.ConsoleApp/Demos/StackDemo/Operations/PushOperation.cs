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
            ConsoleUtilities.Prompt("\nKolik prvku je treba pridat? ");
            var count = ConsoleUtilities.GetUserInput();

            for (var index = 0; index < count; index++)
            {
                try
                {
                    ConsoleUtilities.Prompt($"\nZadejte hodnotu: ");
                    stack.Push(ConsoleUtilities.GetUserInput());
                    ConsoleUtilities.Prompt($"ZASOBNIK: {stack}\n");
                }
                catch (StackOverflowException exception)
                {
                    ConsoleUtilities.Prompt($"\nCHYBA: {exception.Message}\n");
                    break;
                }
            }
        }
    }
}
