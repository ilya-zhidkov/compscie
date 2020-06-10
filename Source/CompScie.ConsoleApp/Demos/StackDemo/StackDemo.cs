using System;
using System.Collections.Generic;
using System.Linq;

using CompScie.ConsoleApp.Demos.StackDemo.Operations;
using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.StackDemo
{
    public class StackDemo
    {
        public static void Show()
        {
            Console.Write("Enter size of a stack: ");
            var stack = new Stack(size: ConsoleUtilities.GetUserInput());

            var operations = new Dictionary<int, IOperation>
            {
                { 1, new PushOperation(stack) },
                { 2, new PopOperation(stack) }
            };

            while (true)
            {
                ConsoleUtilities.DisplayMenu(options: new[] { "\n1. Push", "2. Pop", "3. Quit"});

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
