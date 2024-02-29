using Books.Classes;
using Books.Entities;
using Books.Mappers;
using Books.Models;
using Books.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books
{
    using PathIO = System.IO.Path;
    using Path = Classes.Path;

    public class App
    {
        private Filter _appFilter;
        private LibraryRepository _appLibraryRepository;
        private FileReader _fileReader;

        public App(Filter filter, LibraryRepository libraryRepository, FileReader fileReader) 
        {
            _appFilter = filter;
            _appLibraryRepository = libraryRepository;
            _fileReader = fileReader;
        }

        public void Run(string[] args)
        {
            _appLibraryRepository.DeleteDB();
            _appLibraryRepository.CreateDB();

            string filePath = Path.GetFromArgs(args, nameof(filePath));

            if (filePath == string.Empty)
            {
                Console.WriteLine("Args are empty enter file path: ");

                filePath = Path.GetFromUserInput();
            }

            BookModel[] bookModels = _fileReader.Read(filePath).ToArray();

            List<GenreEntity> genreEntities = BookModelsToGenreEntities.Convert(bookModels);
            List<AuthorEntity> authorEntities = BookModelsToAuthorEntities.Convert(bookModels);
            List<PublisherEntity> publisherEntities = BookModelsToPublisherEntities.Convert(bookModels);

            List<BookEntity> bookEntities = BookModelsToBookEntities.Convert(bookModels, genreEntities, authorEntities, publisherEntities);

            foreach (var bookEntity in bookEntities)
            {
                _appLibraryRepository.AddBook(bookEntity);
            }

            IReadOnlyList<BookEntity> filteredBooksEntities = _appLibraryRepository.FindBooks(_appFilter);

            List<BookModel> result = BookEntitiesToBookModels.Convert(filteredBooksEntities);

            string nameOfDirectory = PathIO.GetDirectoryName(filePath);

            Printer.PrintResultInConsole(result);
            Printer.PrintResultsToFile(nameOfDirectory, result);
        }
    }
}
