﻿using System;
using System.Text;

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

            ConsoleUtilities.Prompt("Setrideno!\n");
             
            FileUtilities.DeleteIfExists(path);

            var builder = new StringBuilder();

            foreach (var number in numbers)
                builder.AppendLine(number.ToString());
                
            FileUtilities.Write(path, builder.ToString().Trim());
        }
    }
}
