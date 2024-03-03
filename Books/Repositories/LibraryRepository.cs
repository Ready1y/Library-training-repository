using System;
using System.Collections.Generic;
using System.Linq;
using Books.Classes;
using Books.DbContext;
using Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Repositories
{
    public class LibraryRepository
    {
        private readonly LibraryContext _context;

        public LibraryRepository(LibraryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context object is null");
            }

            _context = context;
        }

        public void CreateDB()
        {
            _context.Database.EnsureCreated();
        }

        public void DeleteDB()
        {
            _context.Database.EnsureDeleted();
        }

        public void LoadData()
        {
            _context.Books.Load();
            _context.Genres.Load();
            _context.Authors.Load();
            _context.Publishers.Load();
        }

        public void AddBook(BookEntity newBook)
        {
            if(newBook == null)
            {
                throw new ArgumentNullException(nameof(newBook), "New book is null");
            }

            if (newBook.Id == Guid.Empty)
            {
                throw new ArgumentException("New book's id is empty", nameof(newBook));
            }

            if (_context.Books.Any(b => b.Title == newBook.Title && b.Pages == newBook.Pages && b.ReleaseDate == newBook.ReleaseDate))
            {
                return;
            };
                
            _context.Books.Add(newBook);

            _context.SaveChanges();
        }

        public void AddGenre(GenreEntity newGenre)
        {
            if (newGenre == null)
            {
                throw new ArgumentNullException(nameof(newGenre), "New genre is null");
            }

            if (newGenre.Id == Guid.Empty)
            {
                throw new ArgumentException("New genre's id is empty", nameof(newGenre));
            }

            if (_context.Genres.Any(b => b.Name == newGenre.Name))
            {
                return;
            };

            _context.Genres.Add(newGenre);

            _context.SaveChanges();
        }

        public void AddAuthor(AuthorEntity newAuthor)
        {
            if (newAuthor == null)
            {
                throw new ArgumentNullException(nameof(newAuthor), "New author is null");
            }

            if (newAuthor.Id == Guid.Empty)
            {
                throw new ArgumentException("New author's id is empty", nameof(newAuthor));
            }

            if (_context.Authors.Any(b => b.Name == newAuthor.Name))
            {
                return;
            };

            _context.Authors.Add(newAuthor);

            _context.SaveChanges();
        }

        public void AddPublisher(PublisherEntity newPublisher)
        {
            if (newPublisher == null)
            {
                throw new ArgumentNullException(nameof(newPublisher), "New publisher is null");
            }

            if (newPublisher.Id == Guid.Empty)
            {
                throw new ArgumentException("New publisher's id is empty", nameof(newPublisher));
            }

            if (_context.Publishers.Any(b => b.Name == newPublisher.Name))
            {
                return;
            };

            _context.Publishers.Add(newPublisher);

            _context.SaveChanges();
        }

        public void DeleteBook(Guid idOfDeletedEntity)
        {
            if (idOfDeletedEntity == Guid.Empty)
            {
                throw new ArgumentException("Id is empty", nameof(idOfDeletedEntity));
            }

            BookEntity bookToDelete = _context.Books.Find(idOfDeletedEntity);

            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);

                _context.SaveChanges();
            }
        }

        public void DeleteBook(BookEntity bookToDelete)
        {
            if (bookToDelete == null)
            {
                throw new ArgumentNullException(nameof(bookToDelete), "Book to delete is null");
            }

            _context.Books.Remove(bookToDelete);

            _context.SaveChanges();
        }

        public void DeleteGenre(Guid idOfDeletedEntity)
        {
            if (idOfDeletedEntity == Guid.Empty)
            {
                throw new ArgumentException("Id is empty", nameof(idOfDeletedEntity));
            }

            GenreEntity genreToDelete = _context.Genres.Find(idOfDeletedEntity);

            if (genreToDelete != null)
            {
                _context.Genres.Remove(genreToDelete);

                _context.SaveChanges();
            }
        }

        public void DeleteGenre(GenreEntity genreToDelete)
        {
            if (genreToDelete == null)
            {
                throw new ArgumentNullException(nameof(genreToDelete), "Genre to delete is null");
            }

            _context.Genres.Remove(genreToDelete);

            _context.SaveChanges();
        }

        public void DeleteAuthor(Guid idOfDeletedEntity)
        {
            if (idOfDeletedEntity == Guid.Empty)
            {
                throw new ArgumentException("Id is empty", nameof(idOfDeletedEntity));
            }

            AuthorEntity authorToDelete = _context.Authors.Find(idOfDeletedEntity);

            if (authorToDelete != null)
            {
                _context.Authors.Remove(authorToDelete);

                _context.SaveChanges();
            }
        }

        public void DeleteAuthor(AuthorEntity authorToDelete)
        {
            if (authorToDelete == null)
            {
                throw new ArgumentNullException(nameof(authorToDelete), "Author to delete is null");
            }

            _context.Authors.Remove(authorToDelete);

            _context.SaveChanges();
        }

        public void DeletePublisher(Guid idOfDeletedEntity)
        {
            if (idOfDeletedEntity == Guid.Empty)
            {
                throw new ArgumentException("Id is empty", nameof(idOfDeletedEntity));
            }

            PublisherEntity publisherToDelete = _context.Publishers.Find(idOfDeletedEntity);

            if (publisherToDelete != null)
            {
                _context.Publishers.Remove(publisherToDelete);

                _context.SaveChanges();
            }
        }

        public void DeletePublisher(PublisherEntity publisherToDelete)
        {
            if (publisherToDelete == null)
            {
                throw new ArgumentNullException(nameof(publisherToDelete), "Publisher to delete is null");
            }

            _context.Publishers.Remove(publisherToDelete);

            _context.SaveChanges();
        }

        public IReadOnlyList<BookEntity> GetAllBooks()
        {
            IReadOnlyList<BookEntity> books =_context.Books.ToArray();

            return books;
        }

        public IReadOnlyList<GenreEntity> GetAllGenres()
        {
            IReadOnlyList<GenreEntity> genres = _context.Genres.ToArray();

            return genres;
        }

        public IReadOnlyList<AuthorEntity> GetAllAuthors()
        {
            IReadOnlyList<AuthorEntity> authors = _context.Authors.ToArray();

            return authors;
        }

        public IReadOnlyList<PublisherEntity> GetAllPublishers()
        {
            IReadOnlyList<PublisherEntity> publishers = _context.Publishers.ToArray();

            return publishers;
        }

        public BookEntity GetBookById(Guid idOfFindedEntity)
        {
            if (idOfFindedEntity == Guid.Empty)
            {
                throw new ArgumentException("Id is empty", nameof(idOfFindedEntity));
            }

            BookEntity findedBook = _context.Books.Find(idOfFindedEntity);

            return findedBook;
        }

        public GenreEntity GetGenreById(Guid idOfFindedEntity)
        {
            if (idOfFindedEntity == Guid.Empty)
            {
                throw new ArgumentException("Id is empty", nameof(idOfFindedEntity));
            }

            GenreEntity findedGenre = _context.Genres.Find(idOfFindedEntity);

            return findedGenre;
        }

        public AuthorEntity GetAuthorById(Guid idOfFindedEntity)
        {
            if (idOfFindedEntity == Guid.Empty)
            {
                throw new ArgumentException("Id is empty", nameof(idOfFindedEntity));
            }

            AuthorEntity findedAuthor = _context.Authors.Find(idOfFindedEntity);

            return findedAuthor;
        }

        public PublisherEntity GetPublisherById(Guid idOfFindedEntity)
        {
            if (idOfFindedEntity == Guid.Empty)
            {
                throw new ArgumentException("Id is empty", nameof(idOfFindedEntity));
            }

            PublisherEntity findedPublisher = _context.Publishers.Find(idOfFindedEntity);

            return findedPublisher;
        } 

        public void UpdateBook(BookEntity newBookEntity)
        {
            if(newBookEntity == null)
            {
                throw new ArgumentNullException(nameof(newBookEntity), "New book entity is null");
            }

            BookEntity bookToUpdate = _context.Books.Find(newBookEntity.Id);

            if(bookToUpdate != null)
            {
                bookToUpdate.Title = newBookEntity.Title;
                bookToUpdate.Pages = newBookEntity.Pages;
                bookToUpdate.ReleaseDate = newBookEntity.ReleaseDate.ToUniversalTime();
                bookToUpdate.Authors = newBookEntity.Authors;
                bookToUpdate.Publishers = newBookEntity.Publishers;
                bookToUpdate.Genres = newBookEntity.Genres;
            }
        }

        public void UpdateAuthor(AuthorEntity newAuthorEntity)
        {
            if (newAuthorEntity == null)
            {
                throw new ArgumentNullException(nameof(newAuthorEntity), "New author entity is null");
            }

            AuthorEntity authorToUpdate = _context.Authors.Find(newAuthorEntity.Id);

            if (authorToUpdate != null)
            {
                authorToUpdate.Name = newAuthorEntity.Name;
                authorToUpdate.Books = newAuthorEntity.Books;
            }
        }

        public void UpdateGenre(GenreEntity newGenreEntity)
        {
            if (newGenreEntity == null)
            {
                throw new ArgumentNullException(nameof(newGenreEntity), "New genre entity is null");
            }

            GenreEntity genreToUpdate = _context.Genres.Find(newGenreEntity.Id);

            if (genreToUpdate != null)
            {
                genreToUpdate.Name = newGenreEntity.Name;
                genreToUpdate.Books = newGenreEntity.Books;
            }
        }

        public void UpdatePublisher(PublisherEntity newPublisherEntity)
        {
            if (newPublisherEntity == null)
            {
                throw new ArgumentNullException(nameof(newPublisherEntity), "New publisher entity is null");
            }

            PublisherEntity publisherToUpdate = _context.Publishers.Find(newPublisherEntity.Id);

            if (publisherToUpdate != null)
            {
                publisherToUpdate.Name = newPublisherEntity.Name;
                publisherToUpdate.Books = newPublisherEntity.Books;
            }
        }

        public IReadOnlyList<BookEntity> FindBooks(Func<BookEntity, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate is null");
            }

            return _context.Books.AsEnumerable().Where(predicate).ToArray();
        }

        public IReadOnlyList<GenreEntity> FindGenres(Func<GenreEntity, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate is null");
            }

            return _context.Genres.AsEnumerable().Where(predicate).ToArray();
        }

        public IReadOnlyList<AuthorEntity> FindAuthors(Func<AuthorEntity, bool> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate is null");
            }

            return _context.Authors.AsEnumerable().Where(predicate).ToArray();
        }

        public IReadOnlyList<PublisherEntity> FindPublishers(Func<PublisherEntity, bool> predicate)
        {
            if(predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), "Predicate is null");
            }

            return _context.Publishers.AsEnumerable().Where(predicate).ToArray();
        }

        public IReadOnlyList<BookEntity> FindBooks(Filter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter), "Filter is null");
            }

            GenreEntity genreEntity = string.IsNullOrEmpty(filter.Genre)
                ? null
                : _context.Genres.FirstOrDefault(genre => genre.Name == filter.Genre)
            ;


            AuthorEntity authorEntity = string.IsNullOrEmpty(filter.Author)
                ? null
                : _context.Authors.FirstOrDefault(author => author.Name == filter.Author)
            ;


            PublisherEntity publisherEntity = string.IsNullOrEmpty(filter.Publisher)
                ? null
                : publisherEntity = _context.Publishers.FirstOrDefault(publisher => publisher.Name == filter.Publisher)
            ;


            DateTime publishedBeforeNotNull = filter.PublishedBefore ?? DateTime.MinValue;

            DateTime publishedAfterNotNull = filter.PublishedAfter ?? DateTime.MinValue;

            return _context.Books
                .Include(book => book.Authors)
                .Include(book => book.Genres)
                .Include(book => book.Publishers)
                .Where(book =>
                    (string.IsNullOrEmpty(filter.Title) || book.Title == filter.Title)
                    && (string.IsNullOrEmpty(filter.Genre) || book.Genres.Contains(genreEntity))
                    && (string.IsNullOrEmpty(filter.Author) || book.Authors.Contains(authorEntity))
                    && (string.IsNullOrEmpty(filter.Publisher) || book.Publishers.Contains(publisherEntity))
                    && (filter.MoreThanPages == null || book.Pages > filter.MoreThanPages)
                    && (filter.LessThanPages == null || book.Pages < filter.LessThanPages)
                    && (filter.PublishedBefore == null || filter.PublishedBefore == DateTime.MinValue || DateTime.Compare(publishedBeforeNotNull.ToUniversalTime(), book.ReleaseDate) > 0)
                    && (filter.PublishedAfter == null || filter.PublishedAfter == DateTime.MinValue || DateTime.Compare(publishedAfterNotNull.ToUniversalTime(), book.ReleaseDate) < 0)
                )
                .ToArray()
            ;
        }
    }
}
