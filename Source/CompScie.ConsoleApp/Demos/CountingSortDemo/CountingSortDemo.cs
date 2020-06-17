using System;
using System.Linq;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.CountingSortDemo
{
    public class CountingSortDemo
    {
        private const string path = "counting.txt";

        public static void Show()
        {
            var sorter = new CountingSort();

            var numbers = Array.ConvertAll(FileUtilities.Read("cisla.txt"), int.Parse);

            sorter.Sort(numbers, numbers.Max(), numbers.Min());

            FileUtilities.DeleteIfExists(path);

            foreach (var number in numbers)
                FileUtilities.Write(path, number);

            ConsoleUtilities.Prompt("Sorted!\n");
        }
    }
}
