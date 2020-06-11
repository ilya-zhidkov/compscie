using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.GeneratorDemo
{
    public class GeneratorDemo
    {
        public static void Show()
        {
            ConsoleUtilities.Prompt("Enter minimum: ");
            var min = ConsoleUtilities.GetUserInput();

            ConsoleUtilities.Prompt("Enter maximum: ");
            var max = ConsoleUtilities.GetUserInput();

            ConsoleUtilities.Prompt("How many numbers to generate? ");
            var count = ConsoleUtilities.GetUserInput();

            for (int index = 0; index < count; index++)
                FileUtilities.Write("cisla.txt", Generator.Generate(min, max));

            ConsoleUtilities.Prompt("\nDone!\n");
        }
    }
}
