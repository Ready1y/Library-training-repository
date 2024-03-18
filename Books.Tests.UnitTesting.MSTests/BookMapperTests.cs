using Books.Entities;
using Books.Mappers;
using Books.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class BookMapperTests
    {
        [TestMethod]
        public void Test_GetEntities_WhenInputBookModelsAreNull_ThrowsArgumentNullException()
        {
            List<BookModel> bookModels = null;
            List<AuthorEntity> authorEntities = new List<AuthorEntity>();
            List<GenreEntity> genreEntities = new List<GenreEntity>();
            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();

            Action action = () => BookMapper.GetEntities(bookModels, genreEntities, authorEntities, publisherEntities);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_GetEntities_WhenInputAuthorEntitiesAreNull_ThrowsArgumentNullException()
        {
            List<BookModel> bookModels = new List<BookModel>();
            List<AuthorEntity> authorEntities = null;
            List<GenreEntity> genreEntities = new List<GenreEntity>();
            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();

            Action action = () => BookMapper.GetEntities(bookModels, genreEntities, authorEntities, publisherEntities);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_GetEntities_WhenInputGenreEntitiesAreNull_ThrowsArgumentNullException()
        {
            List<BookModel> bookModels = new List<BookModel>();
            List<AuthorEntity> authorEntities = new List<AuthorEntity>();
            List<GenreEntity> genreEntities = null;
            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();

            Action action = () => BookMapper.GetEntities(bookModels, genreEntities, authorEntities, publisherEntities);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_GetEntities_WhenInputPublisherEntitiesAreNull_ThrowsArgumentNullException()
        {
            List<BookModel> bookModels = new List<BookModel>();
            List<AuthorEntity> authorEntities = new List<AuthorEntity>();
            List<GenreEntity> genreEntities = new List<GenreEntity>();
            List<PublisherEntity> publisherEntities = null;

            Action action = () => BookMapper.GetEntities(bookModels, genreEntities, authorEntities, publisherEntities);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_GetEntities_WhenInputIsCorrect_ReturnsBookEntities()
        {
            const string ExpectedTitle = "Title";
            const string ExpectedAuthor = "Author";
            const string ExpectedGenre = "Genre";
            const string ExpectedPublisher = "Publisher";
            const int ExpectedPages = 100;
            DateTime expectedReleaseDate = DateTime.MaxValue;

            BookModel[] bookModel = new BookModel[1];
            bookModel[0] = new BookModel() { Title = ExpectedTitle, Pages = ExpectedPages, ReleaseDate = DateTime.MaxValue, Author = ExpectedAuthor, Genre = ExpectedGenre, Publisher = ExpectedPublisher };

            List<AuthorEntity> authorEntities = new List<AuthorEntity>();
            authorEntities.Add(new AuthorEntity() { Id = Guid.NewGuid(), Name = ExpectedAuthor });

            List<GenreEntity> genreEntities = new List<GenreEntity>();
            genreEntities.Add(new GenreEntity() { Id = Guid.NewGuid(), Name = ExpectedGenre });

            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();
            publisherEntities.Add(new PublisherEntity() { Id = Guid.NewGuid(), Name = ExpectedPublisher });

            List<BookEntity> bookEntities = BookMapper.GetEntities(bookModel, genreEntities, authorEntities, publisherEntities).ToList();

            foreach (BookEntity bookEntity in bookEntities)
            {
                Assert.AreEqual(ExpectedTitle, bookEntity.Title);
                Assert.AreEqual(ExpectedPages, bookEntity.Pages);
                Assert.AreEqual(expectedReleaseDate, bookEntity.ReleaseDate);

                foreach (AuthorEntity authorEntity in authorEntities)
                {
                    Assert.AreEqual(ExpectedAuthor, authorEntity.Name);
                }

                foreach (GenreEntity genreEntity in genreEntities)
                {
                    Assert.AreEqual(ExpectedGenre, genreEntity.Name);
                }

                foreach (PublisherEntity publisherEntity in publisherEntities)
                {
                    Assert.AreEqual(ExpectedPublisher, publisherEntity.Name);
                }
            }
        }

        [TestMethod]
        public void Test_GetModels_WhenInputBookEntitiesAreNull_ThrowsArgumentNullException()
        {
            BookEntity[] bookEntities = null;
            
            Action action = () => BookMapper.GetModels(bookEntities);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_GetModels_WhenInputIsCorrect_ReturnsBookModels()
        {
            const string ExpectedTitle = "Title";
            const int ExpectedPages = 100;
            const string ExpectedAuthors = "Author1;Author2";
            const string ExpectedGenre = "Genre";
            const string ExpectedPublishers= "Publisher1;Publisher2";
            const string Author1 = "Author1";
            const string Author2 = "Author2";
            const string Publisher1 = "Publisher1";
            const string Publisher2 = "Publisher2";

            DateTime expectedReleaseDate = DateTime.MaxValue;

            BookEntity bookEntity = new BookEntity();
            bookEntity.Title = ExpectedTitle;
            bookEntity.Pages = ExpectedPages;
            bookEntity.ReleaseDate = expectedReleaseDate;
            bookEntity.Authors = new List<AuthorEntity>();
            bookEntity.Authors.Add(new AuthorEntity() { Name = Author1 });
            bookEntity.Authors.Add(new AuthorEntity() { Name = Author2 });
            bookEntity.Genres = new List<GenreEntity>();
            bookEntity.Genres.Add(new GenreEntity() { Name = ExpectedGenre });
            bookEntity.Publishers = new List<PublisherEntity>();
            bookEntity.Publishers.Add(new PublisherEntity() { Name = Publisher1 });
            bookEntity.Publishers.Add(new PublisherEntity() { Name = Publisher2 });

            List<BookEntity> bookEntities = new List<BookEntity>();
            bookEntities.Add(bookEntity);
            
            List<BookModel> bookModels = BookMapper.GetModels(bookEntities).ToList();

            foreach (BookModel bookModel in bookModels)
            {
                Assert.AreEqual(ExpectedTitle, bookModel.Title);
                Assert.AreEqual(ExpectedPages, bookModel.Pages);
                Assert.AreEqual(expectedReleaseDate, bookModel.ReleaseDate);
                Assert.AreEqual(ExpectedAuthors, bookModel.Author);
                Assert.AreEqual(ExpectedGenre, bookModel.Genre);
                Assert.AreEqual(ExpectedPublishers, bookModel.Publisher);
            }
        }
    }
}
