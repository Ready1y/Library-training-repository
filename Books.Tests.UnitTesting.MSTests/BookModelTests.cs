using Books.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class BookModelTests
    {
        [TestMethod]
        public void Test_GetTitle_ReturnsTitle()
        {
            const string expectedTitle = "Title";
            BookModel bookModel = new BookModel(expectedTitle, 0, null, null, null, DateTime.MinValue);

            string actualTitle = bookModel.Title;

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void Test_SetTitle_SetValueToTitle()
        {
            const string expectedTitle = "Title";
            const string startTitle = "TitleStart";

            BookModel bookModel = new BookModel(startTitle, 0, null, null, null, DateTime.MinValue);

            bookModel.Title = expectedTitle;

            Assert.AreEqual(expectedTitle, bookModel.Title);
        }

        [TestMethod]
        public void Test_GetPages_ReturnsPages()
        {
            const int expectedPages = 1;
            BookModel bookModel = new BookModel(null, expectedPages, null, null, null, DateTime.MinValue);

            int actualPages = bookModel.Pages;

            Assert.AreEqual(expectedPages, actualPages);
        }

        [TestMethod]
        public void Test_SetPages_SetValueToPages()
        {
            const int expectedPages = 2;
            const int startPages = 1;

            BookModel bookModel = new BookModel(null, startPages, null, null, null, DateTime.MinValue);

            bookModel.Pages = expectedPages;

            Assert.AreEqual(expectedPages, bookModel.Pages);
        }

        [TestMethod]
        public void Test_GetGenre_ReturnsGenre()
        {
            const string expectedGenre = "Genre";
            BookModel bookModel = new BookModel(null, 0, expectedGenre, null, null, DateTime.MinValue);

            string actualGenre = bookModel.Genre;

            Assert.AreEqual(expectedGenre, actualGenre);
        }

        [TestMethod]
        public void Test_SetGenre_SetValueToGenre()
        {
            const string expectedGenre = "Genre";
            const string startGenre = "GenreStart";

            BookModel bookModel = new BookModel(null, 0, startGenre, null, null, DateTime.MinValue);

            bookModel.Genre = expectedGenre;

            Assert.AreEqual(expectedGenre, bookModel.Genre);
        }

        [TestMethod]
        public void Test_GetReleaseDate_ReturnsReleaseDate()
        {
            DateTime expectedReleaseDate = new DateTime(1000, 10, 10);
            BookModel bookModel = new BookModel(null, 0, null, null, null, expectedReleaseDate);

            DateTime actualReleaseDate = bookModel.ReleaseDate;

            Assert.AreEqual(expectedReleaseDate, actualReleaseDate);
        }

        [TestMethod]
        public void Test_SetReleaseDate_SetValueToReleaseDate()
        {
            DateTime expectedReleaseDate = new DateTime(1000, 10, 10);
            DateTime startRealeseDate = DateTime.MinValue;
            BookModel bookModel = new BookModel(null, 0, null, null, null, startRealeseDate);

            bookModel.ReleaseDate = expectedReleaseDate;

            Assert.AreEqual(expectedReleaseDate, bookModel.ReleaseDate);
        }

        [TestMethod]
        public void Test_GetAuthor_ReturnsAuthor()
        {
            const string expectedAuthor = "Author";
            BookModel bookModel = new BookModel(null, 1, null, expectedAuthor, null, DateTime.MinValue);

            string actualAuthor = bookModel.Author;

            Assert.AreEqual(expectedAuthor, actualAuthor);
        }

        [TestMethod]
        public void Test_SetAuthor_SetValueToAuthor()
        {
            const string expectedAuthor = "Author";
            const string startAuthor = "AuthorStart";

            BookModel bookModel = new BookModel(null, 0, null, startAuthor, null, DateTime.MinValue);

            bookModel.Author = expectedAuthor;

            Assert.AreEqual(expectedAuthor, bookModel.Author);
        }

        [TestMethod]
        public void Test_GetPublisher_ReturnsPublisher()
        {
            const string expectedPublisher = "Publisher";
            BookModel bookModel = new BookModel(null, 0, null, null, expectedPublisher, DateTime.MinValue);

            string actualPublisher = bookModel.Publisher;

            Assert.AreEqual(expectedPublisher, actualPublisher);
        }

        [TestMethod]
        public void Test_SetPublisher_SetValueToPublisher()
        {
            const string expectedPublisher = "Publisher";
            const string startPublisher = "PublisherStart";

            BookModel bookModel = new BookModel(null, 0, null, null, startPublisher, DateTime.MinValue);

            bookModel.Publisher = expectedPublisher;

            Assert.AreEqual(expectedPublisher, bookModel.Publisher);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputIsSixParameters_ReturnsModelOfBooksObject()
        {
            const string expectedTitle = "Title";
            const string expectedAuthor = "Author";
            const string expectedGenre = "Genre";
            const string expectedPublisher = "Publisher";
            const int expectedPages = 1;
            DateTime expectedReleaseDate = DateTime.MinValue;

            BookModel bookModel = new BookModel(expectedTitle, expectedPages, expectedGenre, expectedAuthor, expectedPublisher, expectedReleaseDate);

            Assert.AreEqual(expectedTitle, bookModel.Title);
            Assert.AreEqual(expectedAuthor, bookModel.Author);
            Assert.AreEqual(expectedGenre, bookModel.Genre);
            Assert.AreEqual(expectedPublisher, bookModel.Publisher);
            Assert.AreEqual(expectedPages, bookModel.Pages);
            Assert.AreEqual(expectedReleaseDate, bookModel.ReleaseDate);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputIsZeroParameters_ReturnsModelOfBooksObject()
        {
            BookModel actualBookModel = new BookModel();

            Assert.IsNotNull(actualBookModel);
        }
    }
}