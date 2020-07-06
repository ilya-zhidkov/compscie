using System;
using System.Text;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.InsertionSortDemo
{
    public class InsertionSortDemo
    {
        private const string path = "insertion.txt";

        public static void Show()
        {
            var sorter = new InsertionSort();

            var numbers = Array.ConvertAll(FileUtilities.Read("cisla.txt"), int.Parse);

            ConsoleUtilities.Prompt("Probiha trideni dat...\n");

            sorter.Sort(numbers);

            ConsoleUtilities.Prompt("Setrideno!\n");

            ConsoleUtilities.Prompt("Probiha zapis do souboru...\n");

            FileUtilities.DeleteIfExists(path);

            var builder = new StringBuilder();

            foreach (var number in numbers)
                builder.AppendLine(number.ToString());

            FileUtilities.Write(path, builder.ToString().Trim());

            ConsoleUtilities.Prompt("Hotovo!\n");
        }
    }
}
