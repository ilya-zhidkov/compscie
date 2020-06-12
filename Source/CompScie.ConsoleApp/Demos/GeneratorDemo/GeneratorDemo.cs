using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.GeneratorDemo
{
    public class GeneratorDemo
    {
        private const string path = "cisla.txt";

        public static void Show()
        {
            ConsoleUtilities.Prompt("Enter minimum: ");
            var min = ConsoleUtilities.GetUserInput();

            ConsoleUtilities.Prompt("Enter maximum: ");
            var max = ConsoleUtilities.GetUserInput();

            ConsoleUtilities.Prompt("How many numbers to generate? ");
            var count = ConsoleUtilities.GetUserInput();

            FileUtilities.DeleteIfExists(path);

            for (int index = 0; index < count; index++)
                FileUtilities.Write(path, Generator.Generate(min, max));

            ConsoleUtilities.Prompt("\nDone!\n");
        }
    }
}
