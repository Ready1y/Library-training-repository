using Books.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
