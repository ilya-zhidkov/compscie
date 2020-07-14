using System;

using CompScie.ConsoleApp.Demos.StackDemo.Operations;
using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.QueueDemo.Operations
{
    public class DequeueOperation : IOperation
    {
        private readonly CircularQueue queue;

        public DequeueOperation(CircularQueue queue) => this.queue = queue;

        public void Perform()
        {
            ConsoleUtilities.Prompt("\nKolik prvku je treba odebrat? ");
            var count = ConsoleUtilities.GetUserInput();

            for (var index = 0; index < count; index++)
            {
                try
                {
                    ConsoleUtilities.Prompt($"Odebrano: {queue.Dequeue()}\n");
                }
                catch (InvalidOperationException exception)
                {
                    ConsoleUtilities.Prompt($"\nCHYBA: {exception.Message}\n");
                    break;
                }
            }

            ConsoleUtilities.Prompt($"\nFRONTA: {queue}\n");
        }
    }
}
