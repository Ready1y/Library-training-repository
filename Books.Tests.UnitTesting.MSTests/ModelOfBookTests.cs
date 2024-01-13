using Books.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class ModelOfBookTests
    {
        [TestMethod]
        public void Test_GetTitle_ReturnsTitle()
        {
            const string expectedTitle = "Title";
            ModelOfBook modelOfBook = new ModelOfBook(expectedTitle, 0, null, null, null, DateTime.MinValue);

            string actualTitle = modelOfBook.Title;

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void Test_GetPages_ReturnsPages()
        {
            const int expectedPages = 1;
            ModelOfBook modelOfBook = new ModelOfBook(null, expectedPages, null, null, null, DateTime.MinValue);

            int actualPages = modelOfBook.Pages;

            Assert.AreEqual(expectedPages, actualPages);
        }

        [TestMethod]
        public void Test_GetGenre_ReturnsGenre()
        {
            const string expectedGenre = "Genre";
            ModelOfBook modelOfBook = new ModelOfBook(null, 0, expectedGenre, null, null, DateTime.MinValue);

            string actualGenre = modelOfBook.Genre;

            Assert.AreEqual(expectedGenre, actualGenre);
        }

        [TestMethod]
        public void Test_GetReleaseDate_ReturnsReleaseDate()
        {
            DateTime expectedReleaseDate = new DateTime(1000, 10, 10);
            ModelOfBook modelOfBook = new ModelOfBook(null, 0, null, null, null, expectedReleaseDate);

            DateTime actualReleaseDate = modelOfBook.ReleaseDate;

            Assert.AreEqual(expectedReleaseDate, actualReleaseDate);
        }

        [TestMethod]
        public void Test_GetAuthor_ReturnsAuthor()
        {
            const string expectedAuthor = "Author";
            ModelOfBook modelOfBook = new ModelOfBook(null, 1, null, expectedAuthor, null, DateTime.MinValue);

            string actualAuthor = modelOfBook.Author;

            Assert.AreEqual(expectedAuthor, actualAuthor);
        }
        [TestMethod]
        public void Test_GetPublisher_ReturnsPublisher()
        {
            const string expectedPublisher = "Publisher";
            ModelOfBook modelOfBook = new ModelOfBook(null, 0, null, null, expectedPublisher, DateTime.MinValue);

            string actualPublisher = modelOfBook.Publisher;

            Assert.AreEqual(expectedPublisher, actualPublisher);
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

            ModelOfBook modelOfBook = new ModelOfBook(expectedTitle, expectedPages, expectedGenre, expectedAuthor, expectedPublisher, expectedReleaseDate);

            Assert.AreEqual(expectedTitle, modelOfBook.Title);
            Assert.AreEqual(expectedAuthor, modelOfBook.Author);
            Assert.AreEqual(expectedGenre, modelOfBook.Genre);
            Assert.AreEqual(expectedPublisher, modelOfBook.Publisher);
            Assert.AreEqual(expectedPages, modelOfBook.Pages);
            Assert.AreEqual(expectedReleaseDate, modelOfBook.ReleaseDate);
        }

        [TestMethod]
        public void Test_Update_WhenInputParameterNameIsNull_ThrowsArgumentNullException()
        {
            const string parameterName = null;
            const string value = null;

            ModelOfBook book = new ModelOfBook();

            Action action = () => book.Update(parameterName, value);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Update_WhenInputParameterNameIsEmptyString_ThrowsArgumentException()
        {
            string parameterName = string.Empty;
            const string value = null;

            ModelOfBook book = new ModelOfBook();

            Action action = () => book.Update(parameterName, value);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_Update_WhenInputParameterNameIsTitle_UpdateTitle()
        {
            const string parameterName = "Title";
            const string expectedValue = "Title";

            ModelOfBook book = new ModelOfBook();

            book.Update(parameterName, expectedValue);

            Assert.AreEqual(expectedValue, book.Title);
        }

        [TestMethod]
        public void Test_Update_WhenInputParameterNameIsPages_UpdatePages()
        {
            const string parameterName = "Pages";
            const string expectedValue = "10";

            ModelOfBook book = new ModelOfBook();

            book.Update(parameterName, expectedValue);

            Assert.AreEqual(expectedValue, book.Pages.ToString());
        }

        [TestMethod]
        public void Test_Update_WhenInputParameterNameIsGenre_UpdateGenre()
        {
            const string parameterName = "Genre";
            const string expectedValue = "Genre";

            ModelOfBook book = new ModelOfBook();

            book.Update(parameterName, expectedValue);

            Assert.AreEqual(expectedValue, book.Genre);
        }

        [TestMethod]
        public void Test_Update_WhenInputParameterNameIsReleaseDate_UpdateReleaseDate()
        {
            const string parameterName = "ReleaseDate";
            const string expectedValue = "15.10.1960";

            ModelOfBook book = new ModelOfBook();

            book.Update(parameterName, expectedValue);

            Assert.IsTrue(book.ReleaseDate.ToString().Contains(expectedValue));
        }

        [TestMethod]
        public void Test_Update_WhenInputParameterNameIsAuthor_UpdateAuthor()
        {
            const string parameterName = "Author";
            const string expectedValue = "Author";

            ModelOfBook book = new ModelOfBook();

            book.Update(parameterName, expectedValue);

            Assert.AreEqual(expectedValue, book.Author);
        }

        [TestMethod]
        public void Test_Update_WhenInputParameterNameIsPublisher_UpdatePublisher()
        {
            const string parameterName = "Publisher";
            const string expectedValue = "Publisher";

            ModelOfBook book = new ModelOfBook();

            book.Update(parameterName, expectedValue);

            Assert.AreEqual(expectedValue, book.Publisher);
        }
    }
}