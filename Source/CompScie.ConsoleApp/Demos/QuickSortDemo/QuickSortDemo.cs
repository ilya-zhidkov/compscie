using System;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.QuickSortDemo
{
    public class QuickSortDemo
    {
        public static void Show()
        {
            var sorter = new QuickSort();

            var numbers = Array.ConvertAll(FileUtilities.Read("cisla.txt"), int.Parse);

            sorter.Sort(numbers);

            foreach (var number in numbers)
                FileUtilities.Write("quick.txt", number);

            ConsoleUtilities.Prompt("Sorted!\n");
        }
    }
}
