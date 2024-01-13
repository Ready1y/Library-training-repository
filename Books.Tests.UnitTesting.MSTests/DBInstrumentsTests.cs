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
    public class DBInstrumentsTests
    {
        [TestMethod]
        public void Test_AddBook_WhenInputBookIsNull_ThrowsArgumentNullException()
        {
            using (Context context = new Context())
            {
                ModelOfBook book = null;

                Action action = () => DBInstruments.AddBook(context, book);

                Assert.ThrowsException<ArgumentNullException>(action);
            }
        }

        [TestMethod]
        public void Test_AddBook_WhenInputContextIsNull_ThrowsArgumentNullException()
        {
            Context context = null;
            ModelOfBook book = new ModelOfBook();

            Action action = () => DBInstruments.AddBook(context, book);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_AddBook_WhenInputIsCorrect_AddBookToContext()
        {
            using (Context context = new Context())
            {
                const string expectedTitle = "Title";
                const string expectedAuthor = "Author";
                const string expectedGenre = "Genre";
                const string expectedPublisher = "Publisher";
                const int expectedPages = 100;
                DateTime expectedRealeseDate = new DateTime(1900, 10, 10);

                ModelOfBook modelOfBook = new ModelOfBook(expectedTitle, expectedPages, expectedGenre, expectedAuthor, expectedPublisher, expectedRealeseDate);

                DBInstruments.AddBook(context, modelOfBook);

                foreach(var book in context.Books.Local)
                {
                    Assert.AreEqual(expectedTitle, book.Title);
                    Assert.AreEqual(expectedPages, book.Pages);
                    Assert.AreEqual(expectedRealeseDate, book.ReleaseDate);
                }

                foreach (var genre in context.Genres.Local)
                {
                    Assert.AreEqual(expectedGenre, genre.Name);
                }

                foreach (var author in context.Authors.Local)
                {
                    Assert.AreEqual(expectedAuthor, author.Name);
                }

                foreach (var publisher in context.Publishers.Local)
                {
                    Assert.AreEqual(expectedPublisher, publisher.Name);
                }
            }
        }
    }
}