﻿using System.Collections.Generic;
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
            ConsoleUtilities.Prompt("Zadejte velikost fronty: ");
            var queue = new CircularQueue(size: ConsoleUtilities.GetUserInput());

            var operations = new Dictionary<int, IOperation>
            {
                { 1, new EnqueueOperation(queue) },
                { 2, new DequeueOperation(queue) }
            };

            while (true)
            {
                ConsoleUtilities.DisplayMenu(options: new[] { "\n1. Pridat", "2. Odebrat", "3. Odejit" });

                ConsoleUtilities.Prompt("\nZvolte moznost: ");
                var operation = ConsoleUtilities.GetUserInput();

                if (!operations.ContainsKey(operation))
                {
                    ConsoleUtilities.Prompt("\nUkonceni aplikace...\n");
                    break;
                }

                operations.Where(o => o.Key == operation).First().Value.Perform();

                ConsoleUtilities.Prompt($"\n{new string('-', 30)}\n");
            }
        }
    }
}
