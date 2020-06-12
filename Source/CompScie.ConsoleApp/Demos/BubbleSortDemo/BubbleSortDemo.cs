using System;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.BubbleSortDemo
{
    public class BubbleSortDemo
    {
        private const string path = "bubble.txt";

        public static void Show()
        {
            var sorter = new BubbleSort();

            var numbers = Array.ConvertAll(FileUtilities.Read("cisla.txt"), int.Parse);

            sorter.Sort(numbers);

            FileUtilities.DeleteIfExists(path);

            foreach (var number in numbers)
                FileUtilities.Write(path, number);

            ConsoleUtilities.Prompt("Sorted!\n");
        }
    }
}
