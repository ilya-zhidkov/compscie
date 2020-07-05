using System;
using System.Linq;
using System.Text;

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

            ConsoleUtilities.Prompt("Setrideno!\n");

            FileUtilities.DeleteIfExists(path);

            var builder = new StringBuilder();

            foreach (var number in numbers)
                builder.AppendLine(number.ToString());

            FileUtilities.Write(path, builder.ToString().Trim());
        }
    }
}
