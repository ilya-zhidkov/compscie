using System;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.QuickSortDemo
{
    public class QuickSortDemo
    {
        private const string path = "quick.txt";

        public static void Show()
        {
            var sorter = new QuickSort();

            var numbers = Array.ConvertAll(FileUtilities.Read("cisla.txt"), int.Parse);

            sorter.Sort(numbers);

            FileUtilities.DeleteIfExists(path);

            foreach (var number in numbers)
                FileUtilities.Write(path, number);

            ConsoleUtilities.Prompt("Setrideno!\n");
        }
    }
}
