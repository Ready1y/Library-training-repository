using System;

namespace Books.Classes
{
    public class Path
    {
        public static string GetFromArgs(string[] args, string nameOfSearchPath)
        {
            if (args == null || nameOfSearchPath == null)
            {
                return string.Empty;
            }

            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    if (args[i].StartsWith(nameOfSearchPath))
                    {
                        string path = args[i].Replace(nameOfSearchPath, string.Empty).Replace("\"", string.Empty);

                        PathValidator.ValidationForFile(path);

                        return path;
                    }
                }
                catch
                {
                }
            }

            return string.Empty;
        }

        public static string GetFromUserInput()
        {
            string filePath = Console.ReadLine();

            try
            {
                PathValidator.ValidationForFile(filePath);
            }
            catch
            {
                Console.WriteLine("Try to enter file path again: ");
                filePath = GetFromUserInput();
            }

            return filePath;
        }
    }
}
