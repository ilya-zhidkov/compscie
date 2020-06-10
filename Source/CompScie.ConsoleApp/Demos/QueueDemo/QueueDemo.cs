using System.Collections.Generic;
using System.Linq;

using CompScie.ConsoleApp.Demos.QueueDemo.Operations;
using CompScie.ConsoleApp.Demos.StackDemo.Operations;
using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.QueueDemo
{
    public class QueueDemo
    {
        public static void Show()
        {
            ConsoleUtilities.Prompt("Enter size of a queue: ");
            var queue = new CircularQueue(size: ConsoleUtilities.GetUserInput());

            var operations = new Dictionary<int, IOperation>
            {
                { 1, new EnqueueOperation(queue) },
                { 2, new DequeueOperation(queue) }
            };

            while (true)
            {
                ConsoleUtilities.DisplayMenu(options: new[] { "\n1. Enqueue", "2. Dequeue", "3. Quit" });

                ConsoleUtilities.Prompt("\nChoose an option: ");
                var operation = ConsoleUtilities.GetUserInput();

                if (!operations.ContainsKey(operation))
                {
                    ConsoleUtilities.Prompt("\nClosing application...\n");
                    break;
                }

                operations.Where(o => o.Key == operation).First().Value.Perform();

                ConsoleUtilities.Prompt($"\n{new string('-', 30)}\n");
            }
        }
    }
}
