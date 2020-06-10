using System;

using CompScie.ConsoleApp.Demos.StackDemo.Operations;
using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.QueueDemo.Operations
{
    public class EnqueueOperation : IOperation
    {
        private readonly CircularQueue queue;

        public EnqueueOperation(CircularQueue queue) => this.queue = queue;

        public void Perform()
        {
            ConsoleUtilities.Prompt("\nHow many items to enqueue? ");
            var count = ConsoleUtilities.GetUserInput();

            for (var index = 0; index < count; index++)
            {
                try
                {
                    ConsoleUtilities.Prompt($"\nEnter an item to enqueue: ");
                    queue.Enqueue(ConsoleUtilities.GetUserInput());
                    ConsoleUtilities.Prompt($"Queue: {queue}\n");
                }
                catch (InvalidOperationException exception)
                {
                    ConsoleUtilities.Prompt($"\nERROR: {exception.Message}\n");
                    break;
                }
            }
        }
    }
}
