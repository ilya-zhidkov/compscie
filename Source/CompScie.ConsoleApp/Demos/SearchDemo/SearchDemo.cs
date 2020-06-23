using System;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.SearchDemo
{
    public class SearchDemo
    {
        public static void Show()
        {
            var numbers = Array.ConvertAll(FileUtilities.Read("counting.txt"), int.Parse);

            var search = new Search(numbers);

            while (true)
            {
                ConsoleUtilities.Prompt("Zadejte hledany prvek: ");
                var number = ConsoleUtilities.GetUserInput();
            
                var count = search.Lookup(number);

                ConsoleUtilities.Prompt($"\n{(count > 0 ? $"{number} bylo nalezeno {count} krat.\n" : $"{number} nebylo nalezeno.\n")}\n");
            }
        }
    }
}
