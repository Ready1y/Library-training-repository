using Books.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace Books
{
    using PathIO = System.IO.Path;
    using Path = Classes.Path;

    class Program
    {
        static void Main(string[] args)
        {
            string filePathOfFile = Path.GetFromArgs(args, nameof(filePathOfFile));

            if (filePathOfFile == string.Empty)
            {
                Console.WriteLine("Args are empty enter file path: ");

                filePathOfFile = Path.GetFromUserInput();
            }

            ModelOfBook[] arr = FileReader.Read(filePathOfFile);

            using (Context context = new Context())
            {
                context.Database.EnsureCreated();

                context.Books.Load();
                context.Genres.Load();
                context.Authors.Load();
                context.Publishers.Load();

                for (int i = 0; i < arr.Length; i++)
                {
                    DBInstruments.AddBook(context, arr[i]);
                }

                context.SaveChanges();

                var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .Build();

                Filter filter = new Filter(configuration);


                Dictionary<uint, ModelOfBook> result = filter.FindBooksInContext(context);

                string nameOfDirectory = PathIO.GetDirectoryName(filePathOfFile);

                Printer.PrintResultInConsole(result);
                Printer.PrintResultsToFile(nameOfDirectory, result);
            }
        }
    }
}