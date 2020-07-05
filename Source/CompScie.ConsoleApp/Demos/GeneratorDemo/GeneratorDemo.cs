using System.Text;

using CompScie.ConsoleApp.Utilities;
using CompScie.Core;

namespace CompScie.ConsoleApp.Demos.GeneratorDemo
{
    public class GeneratorDemo
    {
        private const string path = "cisla.txt";

        public static void Show()
        {
            ConsoleUtilities.Prompt("Zadejte minimum: ");
            var min = ConsoleUtilities.GetUserInput();

            ConsoleUtilities.Prompt("Zadejte maximum: ");
            var max = ConsoleUtilities.GetUserInput();

            ConsoleUtilities.Prompt("Kolik cisel je treba vygenerovat? ");
            var count = ConsoleUtilities.GetUserInput();

            FileUtilities.DeleteIfExists(path);

            var builder = new StringBuilder();

            for (var index = 0; index < count; index++)
                builder.AppendLine(Generator.Generate(min, max).ToString());
            
            FileUtilities.Write(path, builder.ToString().Trim());

            ConsoleUtilities.Prompt("\nHotovo!\n");
        }
    }
}
