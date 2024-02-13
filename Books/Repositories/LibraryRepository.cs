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
        private LibraryContext _context;

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
                return;
            }

            if (newBook.Id == Guid.Empty)
            {
                return;
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
                return;
            }

            if (newGenre.Id == Guid.Empty)
            {
                return;
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
                return;
            }

            if (newAuthor.Id == Guid.Empty)
            {
                return;
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
                return;
            }

            if (newPublisher.Id == Guid.Empty)
            {
                return;
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
            if (idOfDeletedEntity == null)
            {
                return;
            }

            BookEntity bookToDelete = _context.Books.Find(idOfDeletedEntity);

            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);

                _context.SaveChanges();
            }
        }

        public void DeleteGenre(Guid idOfDeletedEntity)
        {
            if (idOfDeletedEntity == null)
            {
                return;
            }

            GenreEntity genreToDelete = _context.Genres.Find(idOfDeletedEntity);

            if (genreToDelete != null)
            {
                _context.Genres.Remove(genreToDelete);

                _context.SaveChanges();
            }
        }

        public void DeleteAuthor(Guid idOfDeletedEntity)
        {
            if (idOfDeletedEntity == null)
            {
                return;
            }

            AuthorEntity authorToDelete = _context.Authors.Find(idOfDeletedEntity);

            if (authorToDelete != null)
            {
                _context.Authors.Remove(authorToDelete);

                _context.SaveChanges();
            }
        }

        public void DeletePublisher(Guid idOfDeletedEntity)
        {
            if (idOfDeletedEntity == null)
            {
                return;
            }

            PublisherEntity publisherToDelete = _context.Publishers.Find(idOfDeletedEntity);

            if (publisherToDelete != null)
            {
                _context.Publishers.Remove(publisherToDelete);

                _context.SaveChanges();
            }
        }

        public IReadOnlyList<BookEntity> GetAllBooks()
        {
            IReadOnlyList<BookEntity> books =_context.Books.ToList();

            return books;
        }

        public IReadOnlyList<GenreEntity> GetAllGenres()
        {
            IReadOnlyList<GenreEntity> genres = _context.Genres.ToList();

            return genres;
        }

        public IReadOnlyList<AuthorEntity> GetAllAuthors()
        {
            IReadOnlyList<AuthorEntity> authors = _context.Authors.ToList();

            return authors;
        }

        public IReadOnlyList<PublisherEntity> GetAllPublishers()
        {
            IReadOnlyList<PublisherEntity> publishers = _context.Publishers.ToList();

            return publishers;
        }

        public BookEntity GetBookById(Guid idOfFindedEntity)
        {
            if (idOfFindedEntity == null)
            {
                return null;
            }

            BookEntity findedBook = _context.Books.Find(idOfFindedEntity);

            return findedBook;
        }

        public GenreEntity GetGenreById(Guid idOfFindedEntity)
        {
            if (idOfFindedEntity == null)
            {
                return null;
            }

            GenreEntity findedGenre = _context.Genres.Find(idOfFindedEntity);

            return findedGenre;
        }

        public AuthorEntity GetAuthorById(Guid idOfFindedEntity)
        {
            if (idOfFindedEntity == null)
            {
                return null;
            }

            AuthorEntity findedAuthor = _context.Authors.Find(idOfFindedEntity);

            return findedAuthor;
        }

        public PublisherEntity GetPublisherById(Guid idOfFindedEntity)
        {
            if (idOfFindedEntity == null)
            {
                return null;
            }

            PublisherEntity findedPublisher = _context.Publishers.Find(idOfFindedEntity);

            return findedPublisher;
        } 

        public void UpdateBook(BookEntity newBookEntity)
        {
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
            AuthorEntity authorToUpdate = _context.Authors.Find(newAuthorEntity.Id);

            if (authorToUpdate != null)
            {
                authorToUpdate.Name = newAuthorEntity.Name;
                authorToUpdate.Books = newAuthorEntity.Books;
            }
        }

        public void UpdateGenre(GenreEntity newGenreEntity)
        {
            GenreEntity genreToUpdate = _context.Genres.Find(newGenreEntity.Id);

            if (genreToUpdate != null)
            {
                genreToUpdate.Name = newGenreEntity.Name;
                genreToUpdate.Books = newGenreEntity.Books;
            }
        }

        public void UpdatePublisher(PublisherEntity newPublisherEntity)
        {
            PublisherEntity publisherToUpdate = _context.Publishers.Find(newPublisherEntity.Id);

            if (publisherToUpdate != null)
            {
                publisherToUpdate.Name = newPublisherEntity.Name;
                publisherToUpdate.Books = newPublisherEntity.Books;
            }
        }

        public IReadOnlyList<BookEntity> FindBooks(Predicate<BookEntity> predicate)
        {
            return _context.Books.AsEnumerable().Where(book => predicate(book)).ToList().AsReadOnly();
        }

        public IReadOnlyList<GenreEntity> FindGenres(Predicate<GenreEntity> predicate)
        {
            return _context.Genres.AsEnumerable().Where(genre => predicate(genre)).ToList().AsReadOnly();
        }

        public IReadOnlyList<AuthorEntity> FindAuthors(Predicate<AuthorEntity> predicate)
        {
            return _context.Authors.AsEnumerable().Where(author => predicate(author)).ToList().AsReadOnly();
        }

        public IReadOnlyList<PublisherEntity> FindPublishers(Predicate<PublisherEntity> predicate)
        {
            if(predicate == null)
            {
                return null;
            }

            return _context.Publishers.AsEnumerable().Where(publisher => predicate(publisher)).ToList().AsReadOnly();
        }

        public IReadOnlyList<BookEntity> FindBooks(Filter filter)
        {
            if (filter == null)
            {
                return null;
            }

            GenreEntity genreEntity = null;
            if(filter.Genre != null && filter.Genre != string.Empty)
            {
                genreEntity = _context.Genres.FirstOrDefault(genre => genre.Name == filter.Genre); 
            }

            AuthorEntity authorEntity = null;
            if (filter.Author != null && filter.Author != string.Empty)
            {
                authorEntity = _context.Authors.FirstOrDefault(author => author.Name == filter.Author);
            }

            PublisherEntity publisherEntity = null;
            if (filter.Publisher != null && filter.Publisher != string.Empty)
            {
                publisherEntity = _context.Publishers.FirstOrDefault(publisher => publisher.Name == filter.Publisher);
            }

            DateTime publishedBeforeNotNull = DateTime.MinValue;
            if(filter.PublishedBefore != null)
            {
                publishedBeforeNotNull = filter.PublishedBefore.Value;
            }

            DateTime publishedAfterNotNull = DateTime.MinValue;
            if (filter.PublishedAfter != null)
            {
                publishedAfterNotNull = filter.PublishedAfter.Value;
            }

            return _context.Books
                .Include(book => book.Authors)
                .Include(book => book.Genres)
                .Include(book => book.Publishers)
                .Where(book =>
                    (filter.Title == null || filter.Title == string.Empty || book.Title == filter.Title)
                    && (filter.Genre == null || filter.Genre == string.Empty || book.Genres.Contains(genreEntity))
                    && (filter.Author == null || filter.Author == string.Empty || book.Authors.Contains(authorEntity))
                    && (filter.Publisher == null || filter.Publisher == string.Empty || book.Publishers.Contains(publisherEntity))
                    && (filter.MoreThanPages == null || book.Pages > filter.MoreThanPages)
                    && (filter.LessThanPages == null || book.Pages < filter.LessThanPages)
                    && (filter.PublishedBefore == null || filter.PublishedBefore == DateTime.MinValue || DateTime.Compare(publishedBeforeNotNull.ToUniversalTime(), book.ReleaseDate) > 0)
                    && (filter.PublishedAfter == null || filter.PublishedAfter == DateTime.MinValue || DateTime.Compare(publishedAfterNotNull.ToUniversalTime(), book.ReleaseDate) < 0))
                    .ToList().AsReadOnly();
        }
    }
}
