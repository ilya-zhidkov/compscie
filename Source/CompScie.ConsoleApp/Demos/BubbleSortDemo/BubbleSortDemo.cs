using System;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.BubbleSortDemo
{
    public class BubbleSortDemo
    {
        public static void Show()
        {
            var sorter = new BubbleSort();

            var numbers = Array.ConvertAll(FileUtilities.Read("cisla.txt"), int.Parse);

            sorter.Sort(numbers);

            foreach (var number in numbers)
                FileUtilities.Write("bubble.txt", number);

            ConsoleUtilities.Prompt("Sorted!\n");
        }
    }
}
