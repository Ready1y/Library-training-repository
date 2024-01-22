using System;
using Books.DbContext;
using Books.Entities;
using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Classes
{
    public class LibraryRepository
    {
        private LibraryContext _context;

        public LibraryRepository(LibraryContext context) 
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context object is null");
            }

            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void CreateDB()
        {
            _context.Database.EnsureCreated();
        }

        public void LoadData()
        {
            _context.Books.Load();
            _context.Genres.Load();
            _context.Authors.Load();
            _context.Publishers.Load();
        }

        public void AddBook(BookModel book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book is null");
            }

            Guid guidOfGenre = AddGenre(book.Genre);
            Guid guidOfAuthor = AddAuthor(book.Author);
            Guid guidOfPublisher = AddPublisher(book.Publisher);

            foreach(var bookInContext in _context.Books.Local)
            {
                if (bookInContext.Title == book.Title && bookInContext.Pages == book.Pages && bookInContext.GenreId == guidOfGenre && bookInContext.PublisherId == guidOfPublisher && bookInContext.AuthorId == guidOfAuthor)
                {
                    return;
                }
            }

            BookEntity newBook = new BookEntity(Guid.NewGuid(), book.Title, book.Pages, guidOfGenre, guidOfAuthor, guidOfPublisher, book.ReleaseDate);
            _context.Books.Add(newBook);
        }

        private Guid AddGenre(string genreName)
        {
            if(genreName == null)
            {
                throw new ArgumentNullException(nameof(genreName), "Genre name is null");
            }

            bool IsExist = false;
            Guid guid = Guid.Empty;

            foreach(var genre in _context.Genres.Local)
            {
                if(genre.Name == genreName)
                {
                    IsExist = true;

                    guid = genre.Id;

                    break;
                }
            }

            if(!IsExist){
                guid = Guid.NewGuid();

                GenreEntity newGenre = new GenreEntity(guid, genreName);

                _context.Genres.Add(newGenre);
            }

            return guid;
        }

        private Guid AddAuthor(string authorName)
        {
            if (authorName == null)
            {
                throw new ArgumentNullException(nameof(authorName), "Author name is null");
            }

            bool IsExist = false;
            Guid guid = Guid.Empty;

            foreach (var author in _context.Authors.Local)
            {
                if (author.Name == authorName)
                {
                    IsExist = true;

                    guid = author.Id;

                    break;
                }
            }

            if (!IsExist)
            {
                guid = Guid.NewGuid();

                AuthorEntity newAuthor = new AuthorEntity(guid, authorName);

                _context.Authors.Add(newAuthor);
            }

            return guid;
        }

        private Guid AddPublisher(string publisherName)
        {
            if (publisherName == null)
            {
                throw new ArgumentNullException(nameof(publisherName), "Publisher name is null");
            }

            bool IsExist = false;
            Guid guid = Guid.Empty;

            foreach (var publisher in _context.Publishers.Local)
            {
                if (publisher.Name == publisherName)
                {
                    IsExist = true;

                    guid = publisher.Id;

                    break;
                }
            }

            if (!IsExist)
            {
                guid = Guid.NewGuid();

                PublisherEntity newPublisher = new PublisherEntity(guid, publisherName);

                _context.Publishers.Add(newPublisher);
            }

            return guid;
        }
    }
}
