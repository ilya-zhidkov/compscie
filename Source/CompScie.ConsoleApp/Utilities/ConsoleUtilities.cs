using System;

namespace CompScie.ConsoleApp.Utilities
{
    public static class ConsoleUtilities
    {
        public static int GetUserInput() => int.Parse(Console.ReadLine());

        public static void Prompt(string message) => Console.Write(message);

        public static void DisplayMenu(string[] options)
        {
            foreach (var option in options)
                Console.WriteLine(option);
        }
    }
}
