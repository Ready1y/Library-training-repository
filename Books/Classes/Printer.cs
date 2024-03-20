using Books.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Books.Classes
{
    public class Printer
    {
        public static void PrintResultInConsole(IReadOnlyCollection<BookModel> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books), "Dictionary of books is null");
            }

            Console.Write("Count of books with these settings are ");
            Console.WriteLine(books.Count);

            foreach(BookModel book in books)
            {
                Console.WriteLine(book.Title);
            }
        }

        public static void PrintResultsToFile(string directoryOfFile, IReadOnlyCollection<BookModel> books)
        {
            const char Coma = ',';

            if (books == null)
            {
                throw new ArgumentNullException(nameof(books), "Dictionary of books is null");
            }

            PathValidator.ValidationForDirectory(directoryOfFile);

            DateTime time = DateTime.Now;

            string fileName = $"{time:yyyyMMdd_HHmmss}.txt";

            string filePath = System.IO.Path.Combine(directoryOfFile, fileName);

            using (FileStream fileStream = File.Create(filePath))
            {
            }

            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                foreach (BookModel bookModel in books)
                {
                    string formatedDateTime = bookModel.ReleaseDate.ToString("d", CultureInfo.CreateSpecificCulture("en-Us"));

                    streamWriter.Write(bookModel.Title);
                    streamWriter.Write(Coma);
                    streamWriter.Write(bookModel.Pages);
                    streamWriter.Write(Coma);
                    streamWriter.Write(bookModel.Genre);
                    streamWriter.Write(Coma);
                    streamWriter.Write(formatedDateTime);
                    streamWriter.Write(Coma);
                    streamWriter.Write(bookModel.Author);
                    streamWriter.Write(Coma);
                    streamWriter.WriteLine(bookModel.Publisher);
                }
            }
        }
    }
}
