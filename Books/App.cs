using Books.Classes;
using Books.Entities;
using Books.Interfaces;
using Books.Mappers;
using Books.Models;
using System;
using System.Collections.Generic;

namespace Books
{
    using PathIO = System.IO.Path;
    using Path = Classes.Path;

    public class App
    {
        private readonly Filter _appFilter;
        private readonly ILibraryRepository _appLibraryRepository;
        private readonly IFileReader _fileReader;

        public App(Filter filter, ILibraryRepository libraryRepository, IFileReader fileReader) 
        {
            if(filter == null)
            {
                throw new ArgumentNullException(nameof(filter), "Filter is null");
            }

            if(libraryRepository == null)
            {
                throw new ArgumentNullException(nameof(libraryRepository), "Library repository is null");
            }

            if(fileReader == null)
            {
                throw new ArgumentNullException(nameof(fileReader), "File reader is null");
            }

            _appFilter = filter;
            _appLibraryRepository = libraryRepository;
            _fileReader = fileReader;
        }

        public void Run(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args), "Args is null");
            }

            _appLibraryRepository.DeleteDB();
            _appLibraryRepository.CreateDB();

            string filePath = GetPath(args);

            IReadOnlyList<BookModel> bookModels = _fileReader.Read(filePath);

            IReadOnlyList<GenreEntity> genreEntities = GenreMapper.GetEntities(bookModels);
            IReadOnlyList<AuthorEntity> authorEntities = AuthorMapper.GetEntities(bookModels);
            IReadOnlyList<PublisherEntity> publisherEntities = PublisherMapper.GetEntities(bookModels);

            IReadOnlyList<BookEntity> bookEntities = BookMapper.GetEntities(bookModels, genreEntities, authorEntities, publisherEntities);

            foreach (BookEntity bookEntity in bookEntities)
            {
                _appLibraryRepository.AddBook(bookEntity);
            }

            IReadOnlyList<BookEntity> filteredBooksEntities = _appLibraryRepository.FindBooks(_appFilter);

            IReadOnlyList<BookModel> result = BookMapper.GetModels(filteredBooksEntities);

            string nameOfDirectory = PathIO.GetDirectoryName(filePath);

            Printer.PrintResultInConsole(result);
            Printer.PrintResultsToFile(nameOfDirectory, result);
        }

        private static string GetPath(string[] args)
        {
            string filePath = Path.GetFromArgs(args, nameof(filePath));

            if (filePath == string.Empty)
            {
                Console.WriteLine("Args are empty enter file path: ");

                filePath = Path.GetFromUserInput();
            }

            return filePath;
        }
    }
}
