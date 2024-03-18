using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Moq;
using Books.Classes;
using Books.Repositories;
using Books.DbContext;
using Books.Entities;
using Microsoft.EntityFrameworkCore;
using Books.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsCorrect_CreateAppObject()
        {
            LibraryContext libraryContext = new LibraryContext(new DbContextOptions<LibraryContext>());
            Filter filter = new Filter();
            LibraryRepository libraryRepository = new LibraryRepository(libraryContext);
            FileReader fileReader = new FileReader(filter);

            App app = new App(filter, libraryRepository, fileReader);

            Assert.IsNotNull(app);
        }

        [TestMethod]
        public void Test_Constructor_WhenFilterIsNull_ThrowsArgumentNullException()
        {
            LibraryContext libraryContext = new LibraryContext(new DbContextOptions<LibraryContext>());
            Filter filter = null;
            Mock<Filter> filterMock = new Mock<Filter>();
            LibraryRepository libraryRepository = new LibraryRepository(libraryContext);
            FileReader fileReader = new FileReader(filterMock.Object);

            Action action = () => new App(filter, libraryRepository, fileReader);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Constructor_WhenLibraryRepositoryIsNull_ThrowsArgumentNullException()
        {
            Filter filter = new Filter();
            LibraryRepository libraryRepository = null;
            FileReader fileReader = new FileReader(filter);

            Action action = () => new App(filter, libraryRepository, fileReader);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Constructor_WhenFileReaderIsNull_ThrowsArgumentNullException()
        {
            LibraryContext libraryContext = new LibraryContext(new DbContextOptions<LibraryContext>());
            Filter filter = new Filter();
            LibraryRepository libraryRepository = new LibraryRepository(libraryContext);
            FileReader fileReader = null;

            Action action = () => new App(filter, libraryRepository, fileReader);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Run_WhenArgsIsNull_ThrowsArgumentNullException()
        {
            LibraryContext libraryContext = new LibraryContext(new DbContextOptions<LibraryContext>());
            Filter filter = new Filter();
            LibraryRepository libraryRepository = new LibraryRepository(libraryContext);
            FileReader fileReader = new FileReader(filter);

            App app = new App(filter, libraryRepository, fileReader);

            string[] args = null;

            Action action = () => app.Run(args);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Run_WhenInputIsCorrect_ThrowsArgumentNullException()
        {
            const string expectedInputPath = "./Files/books.csv";
            Filter filter = new Filter();

            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();

            List<BookEntity> bookEntities = new List<BookEntity>();

            libraryRepositoryMock
                .Setup(repository => repository.DeleteDB());

            libraryRepositoryMock
                .Setup(repository => repository.CreateDB());

            libraryRepositoryMock
                .Setup(repository => repository.AddBook(It.IsAny<BookEntity>()))
                .Callback(new Action<BookEntity>(entity => 
                {
                    if (bookEntities.Contains(entity))
                    {
                        return;
                    }

                    bookEntities.Add(entity);
                }));

            libraryRepositoryMock
                .Setup(repository => repository.FindBooks(It.IsAny<Filter>()))
                .Returns((Filter filter) =>
                {
                    if (filter == null)
                    {
                        throw new ArgumentNullException(nameof(filter));
                    }

                    return bookEntities.ToList();
                });

            FileReader fileReader = new FileReader(filter);

            App app = new App(filter, libraryRepositoryMock.Object, fileReader);

            string[] args = new string[0];

            using (StringReader stringReader = new StringReader(expectedInputPath))
            {
                Console.SetIn(stringReader);

                app.Run(args);
            }
            
            libraryRepositoryMock.Verify(mock => mock.DeleteDB(), Times.Once);
            libraryRepositoryMock.Verify(mock => mock.CreateDB(), Times.Once);
            libraryRepositoryMock.Verify(mock => mock.FindBooks(It.IsAny<Filter>()), Times.Once);
            Assert.IsTrue(bookEntities.Count != 0);
        }
    }
}
