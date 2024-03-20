using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Moq;
using Books.Classes;
using Books.Repositories;
using Books.Entities;
using Books.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Books.Models;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsCorrect_CreateAppObject()
        {
            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            Filter filter = new Filter();
            Mock<IFileReader> fileReaderMock = new Mock<IFileReader>();

            App app = new App(filter, libraryRepositoryMock.Object, fileReaderMock.Object);

            Assert.IsNotNull(app);
        }

        [TestMethod]
        public void Test_Constructor_WhenFilterIsNull_ThrowsArgumentNullException()
        {
            Mock<Filter> filterMock = new Mock<Filter>();
            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            Mock<IFileReader> fileReaderMock = new Mock<IFileReader>();
            Filter filter = null;

            Action action = () => new App(filter, libraryRepositoryMock.Object, fileReaderMock.Object);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Constructor_WhenLibraryRepositoryIsNull_ThrowsArgumentNullException()
        {
            Filter filter = new Filter();
            LibraryRepository libraryRepository = null;
            Mock<IFileReader> fileReaderMock = new Mock<IFileReader>();

            Action action = () => new App(filter, libraryRepository, fileReaderMock.Object);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Constructor_WhenFileReaderIsNull_ThrowsArgumentNullException()
        {
            Filter filter = new Filter();
            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            FileReader fileReader = null;

            Action action = () => new App(filter, libraryRepositoryMock.Object, fileReader);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Run_WhenArgsIsNull_ThrowsArgumentNullException()
        {
            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            Filter filter = new Filter();
            Mock<IFileReader> fileReaderMock = new Mock<IFileReader>();

            App app = new App(filter, libraryRepositoryMock.Object, fileReaderMock.Object);

            string[] args = null;

            Action action = () => app.Run(args);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Run_WhenInputIsCorrect_ThrowsArgumentNullException()
        {
            const string expectedInputPath = "./Files/books.csv";

            List<BookModel> bookModels = new List<BookModel>();
            bookModels.Add(new BookModel() { Title = "Title1", Pages = 100, ReleaseDate = DateTime.MaxValue, Author = "Author1", Genre = "Genre1", Publisher = "Publisher1" });
            bookModels.Add(new BookModel() { Title = "Title2", Pages = 200, ReleaseDate = DateTime.MinValue, Author = "Author2", Genre = "Genre2", Publisher = "Publisher2" });

            Filter filter = new Filter();

            Mock<ILibraryRepository> libraryRepositoryMock = new Mock<ILibraryRepository>();
            Mock<IFileReader> fileReaderMock = new Mock<IFileReader>();

            List<BookEntity> bookEntities = null;

            libraryRepositoryMock
                .Setup(repository => repository.DeleteDB())
                .Callback(() => 
                { 
                    if(bookEntities != null)
                    {
                        bookEntities.Clear();
                    }
                })
            ;
            

            libraryRepositoryMock
                .Setup(repository => repository.CreateDB())
                .Callback(() => 
                { 
                    if(bookEntities == null)
                    {
                        bookEntities = new List<BookEntity>();
                    }
                })
            ;

            libraryRepositoryMock
                .Setup(repository => repository.AddBook(It.IsAny<BookEntity>()))
                .Callback(new Action<BookEntity>(entity => 
                {
                    if (bookEntities.Contains(entity))
                    {
                        return;
                    }

                    bookEntities.Add(entity);
                }))
            ;

            libraryRepositoryMock
                .Setup(repository => repository.FindBooks(It.IsAny<Filter>()))
                .Returns((Filter filter) =>
                {
                    if (filter == null)
                    {
                        throw new ArgumentNullException(nameof(filter));
                    }

                    return bookEntities;
                })
            ;

            fileReaderMock
                .Setup(reader => reader.Read(It.IsAny<string>()))
                .Returns(bookModels);

            App app = new App(filter, libraryRepositoryMock.Object, fileReaderMock.Object);

            string[] args = Array.Empty<string>();

            using (StringReader stringReader = new StringReader(expectedInputPath))
            {
                Console.SetIn(stringReader);

                app.Run(args);
            }
            
            Assert.IsTrue(bookEntities.Count != 0);
        }
    }
}
