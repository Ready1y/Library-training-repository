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
        private readonly Filter _appFilter;
        private readonly LibraryRepository _appLibraryRepository;
        private readonly FileReader _fileReader;

        public App(Filter filter, LibraryRepository libraryRepository, FileReader fileReader) 
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

            BookModel[] bookModels = _fileReader.Read(filePath).ToArray();

            List<GenreEntity> genreEntities = GenreMapper.GetEntities(bookModels).ToList();
            List<AuthorEntity> authorEntities = AuthorMapper.GetEntities(bookModels).ToList();
            List<PublisherEntity> publisherEntities = PublisherMapper.GetEntities(bookModels).ToList();

            List<BookEntity> bookEntities = BookMapper.GetEntities(bookModels, genreEntities, authorEntities, publisherEntities).ToList();

            foreach (var bookEntity in bookEntities)
            {
                _appLibraryRepository.AddBook(bookEntity);
            }

            IReadOnlyList<BookEntity> filteredBooksEntities = _appLibraryRepository.FindBooks(_appFilter);

            List<BookModel> result = BookMapper.GetModels(filteredBooksEntities);

            string nameOfDirectory = PathIO.GetDirectoryName(filePath);

            Printer.PrintResultInConsole(result);
            Printer.PrintResultsToFile(nameOfDirectory, result);
        }

        private string GetPath(string[] args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args), "Args is null");
            }

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
