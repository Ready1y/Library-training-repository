using Books.Classes;
using Books.DbContext;
using Books.Entities;
using Books.Models;
using Books.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books
{
    using PathIO = System.IO.Path;
    using Path = Classes.Path;

    public class App
    {
        private Filter AppFilter { get; set; }
        private LibraryRepository AppLibraryRepository { get; set; }

        public App() 
        {
            AppFilter = Startup.ServiceProvider.GetService<Filter>();

            AppLibraryRepository = new LibraryRepository(Startup.ServiceProvider.GetService<LibraryContext>());
        }

        public void Run(string[] args)
        {
            Filter AppFilter = Startup.ServiceProvider.GetService<Filter>();

            LibraryRepository AppLibraryRepository = new LibraryRepository(Startup.ServiceProvider.GetService<LibraryContext>());

            AppLibraryRepository.CreateDB();

            string filePathOfFile = Path.GetFromArgs(args, nameof(filePathOfFile));

            if (filePathOfFile == string.Empty)
            {
                Console.WriteLine("Args are empty enter file path: ");

                filePathOfFile = Path.GetFromUserInput();
            }

            BookModel[] bookModels = FileReader.Read(filePathOfFile);

            List<GenreEntity> genreEntities = new List<GenreEntity>();
            List<AuthorEntity> authorEntities = new List<AuthorEntity>();
            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();

            foreach (BookModel bookModel in bookModels)
            {
                GenreEntity genreEntity = new GenreEntity();
                AuthorEntity authorEntity = new AuthorEntity();
                PublisherEntity publisherEntity = new PublisherEntity();

                genreEntity.Id = Guid.NewGuid();
                authorEntity.Id = Guid.NewGuid();
                publisherEntity.Id = Guid.NewGuid();

                genreEntity.Name = bookModel.Genre;
                authorEntity.Name = bookModel.Author;
                publisherEntity.Name = bookModel.Publisher;

                genreEntity.Books = new List<BookEntity>();
                authorEntity.Books = new List<BookEntity>();
                publisherEntity.Books = new List<BookEntity>();

                genreEntities.Add(genreEntity);
                authorEntities.Add(authorEntity);
                publisherEntities.Add(publisherEntity);
            }

            List<BookEntity> bookEntities = new List<BookEntity>();

            foreach (BookModel bookModel in bookModels)
            {
                BookEntity bookEntity = bookEntities.FirstOrDefault(book => book.Title == bookModel.Title && book.Pages == bookModel.Pages && book.ReleaseDate == bookModel.ReleaseDate);

                if (bookEntity == null)
                {
                    bookEntity = new BookEntity();

                    bookEntity.Id = Guid.NewGuid();
                    bookEntity.Title = bookModel.Title;
                    bookEntity.Pages = bookModel.Pages;
                    bookEntity.ReleaseDate = bookModel.ReleaseDate;

                    bookEntity.Genres = new List<GenreEntity>();
                    bookEntity.Genres.Add(genreEntities.FirstOrDefault(genre => genre.Name == bookModel.Genre));

                    bookEntity.Authors = new List<AuthorEntity>();
                    bookEntity.Authors.Add(authorEntities.FirstOrDefault(author => author.Name == bookModel.Author));

                    bookEntity.Publishers = new List<PublisherEntity>();
                    bookEntity.Publishers.Add(publisherEntities.FirstOrDefault(publisher => publisher.Name == bookModel.Publisher));

                    bookEntities.Add(bookEntity);
                }
                else
                {
                    bookEntity.Genres.Add(genreEntities.FirstOrDefault(genre => genre.Name == bookModel.Genre));

                    bookEntity.Authors.Add(authorEntities.FirstOrDefault(author => author.Name == bookModel.Author));

                    bookEntity.Publishers.Add(publisherEntities.FirstOrDefault(publisher => publisher.Name == bookModel.Publisher));
                }
            }

            foreach (var bookEntity in bookEntities)
            {
                AppLibraryRepository.AddBook(bookEntity);
            }

            List<BookEntity> filteredBooksEntities = AppLibraryRepository.FindBooks(AppFilter).ToList();

            List<BookModel> result = new List<BookModel>();

            foreach (BookEntity bookEntity in filteredBooksEntities) 
            {
                BookModel bookModel = new BookModel();

                bookModel.Title = bookEntity.Title;
                bookModel.Pages = bookEntity.Pages;
                bookModel.ReleaseDate = bookEntity.ReleaseDate;

                StringBuilder genreStringBuilder = new StringBuilder();
                foreach (GenreEntity genreEntity in bookEntity.Genres)
                {
                    genreStringBuilder.Append(genreEntity.Name);
                    genreStringBuilder.Append(';');
                }
                bookModel.Genre = genreStringBuilder.Remove(genreStringBuilder.Length - 1, 1).ToString();

                StringBuilder authorStringBuilder = new StringBuilder();
                foreach (AuthorEntity authorEntity in bookEntity.Authors)
                {
                    authorStringBuilder.Append(authorEntity.Name);
                    authorStringBuilder.Append(';');
                }
                bookModel.Author = authorStringBuilder.Remove(authorStringBuilder.Length - 1, 1).ToString();

                StringBuilder publisherStringBuilder = new StringBuilder();
                foreach (PublisherEntity publisherEntity in bookEntity.Publishers)
                {
                    publisherStringBuilder.Append(publisherEntity.Name);
                    publisherStringBuilder.Append(';');
                }
                bookModel.Publisher = publisherStringBuilder.Remove(publisherStringBuilder.Length - 1, 1).ToString();

                result.Add(bookModel);
            }

            string nameOfDirectory = PathIO.GetDirectoryName(filePathOfFile);

            Printer.PrintResultInConsole(result);
            Printer.PrintResultsToFile(nameOfDirectory, result);
        }
    }
}
