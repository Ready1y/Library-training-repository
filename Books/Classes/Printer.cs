using Books.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Books.Classes
{
    public class Printer
    {
        public static void PrintResultInConsole(List<BookModel> listOfBooks)
        {
            if (listOfBooks == null)
            {
                throw new ArgumentNullException(nameof(listOfBooks), "Dictiunary of books is null");
            }

            Console.Write("Count of books with these settings are ");
            Console.WriteLine(listOfBooks.Count);

            if (listOfBooks.Count != 0)
            {
                foreach(BookModel book in listOfBooks)
                {
                    Console.WriteLine(book.Title);
                }
            }
        }

        public static void PrintResultsToFile(string directoryOfFile, List<BookModel> listOfBooks)
        {
            if (listOfBooks == null)
            {
                throw new ArgumentNullException(nameof(listOfBooks), "Dictiunary of books is null");
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
                foreach (BookModel bookModel in listOfBooks)
                {
                    streamWriter.Write(bookModel.Title);
                    streamWriter.Write(",");
                    streamWriter.Write(bookModel.Pages);
                    streamWriter.Write(",");
                    streamWriter.Write(bookModel.Genre);
                    streamWriter.Write(",");
                    streamWriter.Write(bookModel.ReleaseDate.ToShortDateString());
                    streamWriter.Write(",");
                    streamWriter.Write(bookModel.Author);
                    streamWriter.Write(",");
                    streamWriter.WriteLine(bookModel.Publisher);
                }
            }
        }
    }
}
