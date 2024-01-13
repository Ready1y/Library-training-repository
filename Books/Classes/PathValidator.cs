using System;
using System.IO;

namespace Books.Classes
{
    using PathIO = System.IO.Path;

    public class PathValidator
    {
        public static void ValidationForFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("The path is null, empty or consists only of spaces.", nameof(filePath));
            }

            char[] invalidPathChars = PathIO.GetInvalidPathChars();

            if (filePath.IndexOfAny(invalidPathChars) != -1)
            {
                throw new ArgumentException("Wrong file path, invalid chars into file path", nameof(filePath));
            }

            string nameOfDirectory = PathIO.GetDirectoryName(filePath);

            if (!Directory.Exists(nameOfDirectory))
            {
                throw new DirectoryNotFoundException("Wrong directory path");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Wrong file path", nameof(filePath));
            }
        }

        public static void ValidationForDirectory(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new ArgumentException("The path is null, empty or consists only of spaces.", nameof(directoryPath));
            }

            char[] invalidPathChars = PathIO.GetInvalidPathChars();

            if (directoryPath.IndexOfAny(invalidPathChars) != -1)
            {
                throw new ArgumentException("Wrong file path, invalid chars into file path", nameof(directoryPath));
            }

            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException("Wrong directory path");
            }
        }
    }
}
