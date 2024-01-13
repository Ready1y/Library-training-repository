using Books.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Books.Classes
{
    public class Printer
    {
        public static void PrintResultInConsole(Dictionary<uint, ModelOfBook> dictiunaryOfBooks)
        {
            if(dictiunaryOfBooks == null)
            {
                throw new ArgumentNullException(nameof(dictiunaryOfBooks), "Dictiunary of books is null");
            }

            Console.Write("Count of books with these settings are ");
            Console.WriteLine(dictiunaryOfBooks.Count);

            if(dictiunaryOfBooks.Count != 0)
            {
                for(uint i = 1;  i <= dictiunaryOfBooks.Count; i++)
                {
                    Console.WriteLine(dictiunaryOfBooks[i].Title);
                }
            }
        }

        public static void PrintResultsToFile(string directoryOfFile, Dictionary<uint, ModelOfBook> dictiunaryOfBooks)
        {
            if (dictiunaryOfBooks == null)
            {
                throw new ArgumentNullException(nameof(dictiunaryOfBooks), "Dictiunary of books is null");
            }

            PathValidator.ValidationForDirectory(directoryOfFile);

            StringBuilder filePath = new StringBuilder(directoryOfFile);

            DateTime time = DateTime.Now;

            string fileName = $"{time:yyyyMMdd_HHmmss}.txt";

            filePath.Append(fileName);

            using (FileStream fileStream = File.Create(filePath.ToString()))
            {
            }

            using (StreamWriter streamWriter = new StreamWriter(filePath.ToString()))
            {
                for (uint i = 1; i <= dictiunaryOfBooks.Count; i++)
                {
                    streamWriter.Write(dictiunaryOfBooks[i].Title);
                    streamWriter.Write(",");
                    streamWriter.Write(dictiunaryOfBooks[i].Pages);
                    streamWriter.Write(",");
                    streamWriter.Write(dictiunaryOfBooks[i].Genre);
                    streamWriter.Write(",");
                    streamWriter.Write(dictiunaryOfBooks[i].ReleaseDate.ToShortDateString());
                    streamWriter.Write(",");
                    streamWriter.Write(dictiunaryOfBooks[i].Author);
                    streamWriter.Write(",");
                    streamWriter.WriteLine(dictiunaryOfBooks[i].Publisher);
                }
            }
        }
    }
}
