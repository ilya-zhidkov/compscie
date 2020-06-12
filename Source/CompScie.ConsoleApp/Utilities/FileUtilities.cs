using System.IO;

namespace CompScie.ConsoleApp.Utilities
{
    public static class FileUtilities
    {
        public static void Write(string path, object data) => File.AppendAllText(path, $"{data}\n");

        public static string[] Read(string path) => File.ReadAllLines(path);
    }
}
