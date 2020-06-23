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
            ConsoleUtilities.Prompt("\nKolik prvku je treba pridat? ");
            var count = ConsoleUtilities.GetUserInput();

            for (var index = 0; index < count; index++)
            {
                try
                {
                    ConsoleUtilities.Prompt($"\nZadejte hodnotu: ");
                    queue.Enqueue(ConsoleUtilities.GetUserInput());
                    ConsoleUtilities.Prompt($"FRONTA: {queue}\n");
                }
                catch (InvalidOperationException exception)
                {
                    ConsoleUtilities.Prompt($"\nCHYBA: {exception.Message}\n");
                    break;
                }
            }
        }
    }
}
