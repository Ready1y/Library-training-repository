using Books.Classes;
using Books.DbContext;
using Books.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Books
{
    using PathIO = System.IO.Path;
    using Path = Classes.Path;
    public class App
    {
        public void Run(string[] args)
        {
            string filePathOfFile = Path.GetFromArgs(args, nameof(filePathOfFile));

            if (filePathOfFile == string.Empty)
            {
                Console.WriteLine("Args are empty enter file path: ");

                filePathOfFile = Path.GetFromUserInput();
            }

            BookModel[] arr = FileReader.Read(filePathOfFile);

            using (LibraryContext context = new LibraryContext())
            {
                LibraryRepository libraryRepository = new LibraryRepository(context);

                libraryRepository.CreateDB();

                libraryRepository.LoadData();

                for (int i = 0; i < arr.Length; i++)
                {
                    libraryRepository.AddBook(arr[i]);
                }

                libraryRepository.Save();

                var configuration = Startup.ServiceProvider.GetService<IConfiguration>();
                Filter filter = new Filter(configuration);

                Dictionary<uint, BookModel> result = filter.FindBooksInContext(context);

                string nameOfDirectory = PathIO.GetDirectoryName(filePathOfFile);

                Printer.PrintResultInConsole(result);
                Printer.PrintResultsToFile(nameOfDirectory, result);
            }
        }
    }
}
