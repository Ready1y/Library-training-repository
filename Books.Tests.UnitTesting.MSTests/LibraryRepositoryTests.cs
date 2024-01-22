using Books.Classes;
using Books.DbContext;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class LibraryRepositoryTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputContextIsNull()
        {
            LibraryContext context = null;
         
            Action action = () => new LibraryRepository(context);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputContextIsCorrect()
        {
            using (LibraryContext context = new LibraryContext())
            {
                Action action = () => new LibraryRepository(context);
            }
        }

        [TestMethod]
        public void Test_Save_CallsSaveChanges() 
        {
            var contextMock = new Mock<LibraryContext>();
            var repository = new LibraryRepository(contextMock.Object);

            repository.Save();

            contextMock.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_CreateDB_CreateDB()    
        {
            var contextMock = new Mock<LibraryContext>();
            contextMock.Setup(c => c.Database).Returns(Mock.Of<DatabaseFacade>());

            LibraryRepository repository = new LibraryRepository(contextMock.Object);

            repository.CreateDB();

            contextMock.Verify(c => c.Database.EnsureCreated(), Times.Once);
        }
        
        [TestMethod]
        public void Test_Load_LoadTheEntitiesToContext()    
        {
            var contextMock = new Mock<LibraryContext>();

            LibraryRepository repository = new LibraryRepository(contextMock.Object);

            repository.LoadData();

            contextMock.Verify(c => c.Books.Load(), Times.Once);
            contextMock.Verify(c => c.Genres.Load(), Times.Once);
            contextMock.Verify(c => c.Authors.Load(), Times.Once);
            contextMock.Verify(c => c.Publishers.Load(), Times.Once);
        }



        [TestMethod]
        public void Test_AddBook_WhenInputBookIsNull_ThrowsArgumentNullException()
        {
            using (LibraryContext context = new LibraryContext())
            {
                BookModel book = null;

                LibraryRepository libraryRepository = new LibraryRepository(context);

                Action action = () => libraryRepository.AddBook(book);

                Assert.ThrowsException<ArgumentNullException>(action);
            }
        }

        [TestMethod]
        public void Test_AddBook_WhenInputIsCorrect_AddBookToContext()
        {
            using (LibraryContext context = new LibraryContext())
            {
                const string expectedTitle = "Title";
                const string expectedAuthor = "Author";
                const string expectedGenre = "Genre";
                const string expectedPublisher = "Publisher";
                const int expectedPages = 100;
                DateTime expectedRealeseDate = new DateTime(1900, 10, 10);

                BookModel modelOfBook = new BookModel(expectedTitle, expectedPages, expectedGenre, expectedAuthor, expectedPublisher, expectedRealeseDate);

                LibraryRepository libraryRepository = new LibraryRepository(context);

                libraryRepository.AddBook(modelOfBook);

                foreach (var book in context.Books.Local)
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