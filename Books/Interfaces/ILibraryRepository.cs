using Books.Classes;
using Books.Entities;
using System;
using System.Collections.Generic;

namespace Books.Interfaces
{
    public interface ILibraryRepository
    {
        public void CreateDB();
        public void DeleteDB();
        public void LoadData();

        public void AddBook(BookEntity newBook);
        public void AddGenre(GenreEntity newGenre);
        public void AddAuthor(AuthorEntity newAuthor);
        public void AddPublisher(PublisherEntity newPublisher);

        public void DeleteBook(Guid idOfDeletedEntity);
        public void DeleteBook(BookEntity bookToDelete);
        public void DeleteGenre(Guid idOfDeletedEntity);
        public void DeleteGenre(GenreEntity genreToDelete);
        public void DeleteAuthor(Guid idOfDeletedEntity);
        public void DeleteAuthor(AuthorEntity authorToDelete);
        public void DeletePublisher(Guid idOfDeletedEntity);
        public void DeletePublisher(PublisherEntity publisherToDelete);

        public IReadOnlyList<BookEntity> GetAllBooks();
        public IReadOnlyList<GenreEntity> GetAllGenres();
        public IReadOnlyList<AuthorEntity> GetAllAuthors();
        public IReadOnlyList<PublisherEntity> GetAllPublishers();

        public BookEntity GetBookById(Guid idOfFindedEntity);
        public GenreEntity GetGenreById(Guid idOfFindedEntity);
        public AuthorEntity GetAuthorById(Guid idOfFindedEntity);
        public PublisherEntity GetPublisherById(Guid idOfFindedEntity);

        public void UpdateBook(BookEntity newBookEntity);
        public void UpdateAuthor(AuthorEntity newAuthorEntity);
        public void UpdateGenre(GenreEntity newGenreEntity);
        public void UpdatePublisher(PublisherEntity newPublisherEntity);

        public IReadOnlyList<BookEntity> FindBooks(Func<BookEntity, bool> predicate);
        public IReadOnlyList<BookEntity> FindBooks(Filter filter);
        public IReadOnlyList<GenreEntity> FindGenres(Func<GenreEntity, bool> predicate);
        public IReadOnlyList<AuthorEntity> FindAuthors(Func<AuthorEntity, bool> predicate);
        public IReadOnlyList<PublisherEntity> FindPublishers(Func<PublisherEntity, bool> predicate);
    }
}
