using Books.Classes;
using Books.DbContext;
using Books.Entities;
using Books.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class LibraryRepositoryTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputContextIsNull_ThrowsArgumentNullException()
        {
            LibraryContext libraryContext = null;

            Action action = () =>  new LibraryRepository(libraryContext);
            
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputContextIsCorrect_ReturnsLibraryRepositoryObject()
        {
            LibraryContext libraryContext = new LibraryContext(new DbContextOptions<LibraryContext>());

            LibraryRepository libraryRepository = new LibraryRepository(libraryContext);

            Assert.IsNotNull(libraryRepository);
        }

        [TestMethod]
        public void Test_AddBook_WhenInputEntityIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            BookEntity bookEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.AddBook(bookEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_AddBook_WhenInputEntityIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            BookEntity bookEntity = new BookEntity() { Id = Guid.Empty };

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.AddBook(bookEntity);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_AddBook_WhenInputIsCorrect_AddBookToList()
        {
            const string ExpectedTilte = "Title";
            const int ExpectedPages = 100;
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            BookEntity bookEntity = new BookEntity() { Id = Guid.NewGuid(), Title = ExpectedTilte, Pages = ExpectedPages };

            List<BookEntity> bookEntities = new List<BookEntity>();

            libraryContextMock
                .Setup(x => x.Books)
                .ReturnsDbSet(GetFakeBooksList());

            libraryContextMock
                .Setup(x => x.Books.Add(It.IsAny<BookEntity>()))
                .Callback(new Action<BookEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    bookEntities.Add(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.AddBook(bookEntity);

            Assert.IsNotNull(bookEntities);
            foreach (BookEntity entity in bookEntities) 
            {
                Assert.AreEqual(ExpectedTilte, entity.Title);
                Assert.AreEqual(ExpectedPages, entity.Pages);
            }
        }

        [TestMethod]
        public void Test_AddAuthor_WhenInputEntityIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            AuthorEntity authorEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.AddAuthor(authorEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_AddAuthor_WhenInputEntityIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            AuthorEntity authorEntity = new AuthorEntity() { Id = Guid.Empty };

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.AddAuthor(authorEntity);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_AddAuthor_WhenInputIsCorrect_AddBookToList()
        {
            const string ExpectedName = "Title";
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            AuthorEntity AuthorEntity = new AuthorEntity() { Id = Guid.NewGuid(), Name = ExpectedName };

            List<AuthorEntity> authorEntities = new List<AuthorEntity>();

            libraryContextMock
                .Setup(x => x.Authors)
                .ReturnsDbSet(GetFakeAuthorsList());

            libraryContextMock
                .Setup(x => x.Authors.Add(It.IsAny<AuthorEntity>()))
                .Callback(new Action<AuthorEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    authorEntities.Add(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.AddAuthor(AuthorEntity);

            Assert.IsNotNull(authorEntities);
            foreach (AuthorEntity entity in authorEntities)
            {
                Assert.AreEqual(ExpectedName, entity.Name);
            }
        }

        [TestMethod]
        public void Test_AddGenre_WhenInputEntityIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            GenreEntity genreEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.AddGenre(genreEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_AddGenre_WhenInputEntityIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            GenreEntity authorEntity = new GenreEntity() { Id = Guid.Empty };

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.AddGenre(authorEntity);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_AddGenre_WhenInputIsCorrect_AddBookToList()
        {
            const string ExpectedName = "Title";
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            GenreEntity AuthorEntity = new GenreEntity() { Id = Guid.NewGuid(), Name = ExpectedName };

            List<GenreEntity> authorEntities = new List<GenreEntity>();

            libraryContextMock
                .Setup(x => x.Genres)
                .ReturnsDbSet(GetFakeGenresList());

            libraryContextMock
                .Setup(x => x.Genres.Add(It.IsAny<GenreEntity>()))
                .Callback(new Action<GenreEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    authorEntities.Add(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.AddGenre(AuthorEntity);

            Assert.IsNotNull(authorEntities);
            foreach (GenreEntity entity in authorEntities)
            {
                Assert.AreEqual(ExpectedName, entity.Name);
            }
        }

        [TestMethod]
        public void Test_AddPublisher_WhenInputEntityIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            PublisherEntity publisherEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.AddPublisher(publisherEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_AddPublisher_WhenInputEntityIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            PublisherEntity authorEntity = new PublisherEntity() { Id = Guid.Empty };

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.AddPublisher(authorEntity);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_AddPublisher_WhenInputIsCorrect_AddBookToList()
        {
            const string ExpectedName = "Title";
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            PublisherEntity AuthorEntity = new PublisherEntity() { Id = Guid.NewGuid(), Name = ExpectedName };

            List<PublisherEntity> authorEntities = new List<PublisherEntity>();

            libraryContextMock
                .Setup(x => x.Publishers)
                .ReturnsDbSet(GetFakePublishersList());

            libraryContextMock
                .Setup(x => x.Publishers.Add(It.IsAny<PublisherEntity>()))
                .Callback(new Action<PublisherEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    authorEntities.Add(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.AddPublisher(AuthorEntity);

            Assert.IsNotNull(authorEntities);
            foreach (PublisherEntity entity in authorEntities)
            {
                Assert.AreEqual(ExpectedName, entity.Name);
            }
        }

        [TestMethod]
        public void Test_DeleteBook_WhenInputIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.Empty;
            BookEntity bookEntity = new BookEntity() { Id = id };

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.DeleteBook(id);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_DeleteBook_WhenInputIsId_DeleteBookFromList()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.NewGuid();
            BookEntity bookEntity = new BookEntity() { Id = id };

            List<BookEntity> bookEntities = new List<BookEntity>();
            bookEntities.Add(bookEntity);

            libraryContextMock 
                .Setup(x => x.Books.Find(It.IsAny<Guid>()))
                .Returns(bookEntity);

            libraryContextMock
                .Setup(x => x.Books.Remove(It.IsAny<BookEntity>()))
                .Callback(new Action<BookEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    bookEntities.Remove(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.DeleteBook(id);

            Assert.IsNotNull(bookEntities);
            Assert.IsTrue(bookEntities.Count == 0);
        }

        [TestMethod]
        public void Test_DeleteBook_WhenInputEntityIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            BookEntity bookEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.DeleteBook(bookEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_DeleteBook_WhenInputIsEntity_DeleteBookFromList()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            BookEntity bookEntity = new BookEntity() { Id = Guid.NewGuid() };

            List<BookEntity> bookEntities = new List<BookEntity>();
            bookEntities.Add(bookEntity);

            libraryContextMock
                .Setup(x => x.Books.Remove(It.IsAny<BookEntity>()))
                .Callback(new Action<BookEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    bookEntities.Remove(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.DeleteBook(bookEntity);

            Assert.IsNotNull(bookEntities);
            Assert.IsTrue(bookEntities.Count == 0);
        }

        [TestMethod]
        public void Test_DeleteAuthor_WhenInputIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.Empty;
            AuthorEntity authorEntity = new AuthorEntity() { Id = id };

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.DeleteAuthor(id);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_DeleteAuthor_WhenInputIsId_DeleteBookFromList()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.NewGuid();
            AuthorEntity authorEntity = new AuthorEntity() { Id = id };

            List<AuthorEntity> authorEntities = new List<AuthorEntity>();
            authorEntities.Add(authorEntity);

            libraryContextMock
                .Setup(x => x.Authors.Find(It.IsAny<Guid>()))
                .Returns(authorEntity);

            libraryContextMock
                .Setup(x => x.Authors.Remove(It.IsAny<AuthorEntity>()))
                .Callback(new Action<AuthorEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    authorEntities.Remove(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.DeleteAuthor(id);

            Assert.IsNotNull(authorEntities);
            Assert.IsTrue(authorEntities.Count == 0);
        }

        [TestMethod]
        public void Test_DeleteAuthor_WhenInputEntityIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            AuthorEntity authorEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.DeleteAuthor(authorEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_DeleteAuthor_WhenInputIsEntity_DeleteBookFromList()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            AuthorEntity authorEntity = new AuthorEntity() { Id = Guid.NewGuid() };

            List<AuthorEntity> authorEntities = new List<AuthorEntity>();
            authorEntities.Add(authorEntity);

            libraryContextMock
                .Setup(x => x.Authors.Remove(It.IsAny<AuthorEntity>()))
                .Callback(new Action<AuthorEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    authorEntities.Remove(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.DeleteAuthor(authorEntity);

            Assert.IsNotNull(authorEntities);
            Assert.IsTrue(authorEntities.Count == 0);
        }

        [TestMethod]
        public void Test_DeleteGenre_WhenInputIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.Empty;
            GenreEntity genreEntity = new GenreEntity() { Id = id };

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.DeleteGenre(id);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_DeleteGenre_WhenInputIsId_DeleteBookFromList()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.NewGuid();
            GenreEntity genreEntity = new GenreEntity() { Id = id };

            List<GenreEntity> genreEntities = new List<GenreEntity>();
            genreEntities.Add(genreEntity);

            libraryContextMock
                .Setup(x => x.Genres.Find(It.IsAny<Guid>()))
                .Returns(genreEntity);

            libraryContextMock
                .Setup(x => x.Genres.Remove(It.IsAny<GenreEntity>()))
                .Callback(new Action<GenreEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    genreEntities.Remove(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.DeleteGenre(id);

            Assert.IsNotNull(genreEntities);
            Assert.IsTrue(genreEntities.Count == 0);
        }

        [TestMethod]
        public void Test_DeleteGenre_WhenInputEntityIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            GenreEntity genreEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.DeleteGenre(genreEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_DeleteGenre_WhenInputIsEntity_DeleteBookFromList()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            GenreEntity genreEntity = new GenreEntity() { Id = Guid.NewGuid() };

            List<GenreEntity> genreEntities = new List<GenreEntity>();
            genreEntities.Add(genreEntity);

            libraryContextMock
                .Setup(x => x.Genres.Remove(It.IsAny<GenreEntity>()))
                .Callback(new Action<GenreEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    genreEntities.Remove(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.DeleteGenre(genreEntity);

            Assert.IsNotNull(genreEntities);
            Assert.IsTrue(genreEntities.Count == 0);
        }

        [TestMethod]
        public void Test_DeletePublisher_WhenInputIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.Empty;
            PublisherEntity publisherEntity = new PublisherEntity() { Id = id };

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.DeletePublisher(id);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_DeletePublisher_WhenInputIsId_DeleteBookFromList()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.NewGuid();
            PublisherEntity publisherEntity = new PublisherEntity() { Id = id };

            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();
            publisherEntities.Add(publisherEntity);

            libraryContextMock
                .Setup(x => x.Publishers.Find(It.IsAny<Guid>()))
                .Returns(publisherEntity);

            libraryContextMock
                .Setup(x => x.Publishers.Remove(It.IsAny<PublisherEntity>()))
                .Callback(new Action<PublisherEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    publisherEntities.Remove(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.DeletePublisher(id);

            Assert.IsNotNull(publisherEntities);
            Assert.IsTrue(publisherEntities.Count == 0);
        }

        [TestMethod]
        public void Test_DeletePublisher_WhenInputEntityIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            PublisherEntity publisherEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.DeletePublisher(publisherEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_DeletePublisher_WhenInputIsEntity_DeleteBookFromList()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            PublisherEntity publisherEntity = new PublisherEntity() { Id = Guid.NewGuid() };

            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();
            publisherEntities.Add(publisherEntity);

            libraryContextMock
                .Setup(x => x.Publishers.Remove(It.IsAny<PublisherEntity>()))
                .Callback(new Action<PublisherEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    publisherEntities.Remove(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.DeletePublisher(publisherEntity);

            Assert.IsNotNull(publisherEntities);
            Assert.IsTrue(publisherEntities.Count == 0);
        }

        [TestMethod]
        public void Test_GetAllBooks_ReturnsAllBooks()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();

            List<BookEntity> bookEntities = new List<BookEntity>();

            libraryContextMock
                .Setup(x => x.Books)
                .ReturnsDbSet(GetFakeBooksList());

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            bookEntities = libraryRepository.GetAllBooks().ToList();

            Assert.IsNotNull(bookEntities);
            Assert.IsTrue(bookEntities.Count == 2);
        }

        [TestMethod]
        public void Test_GetAllAuthors_ReturnsAllAuthors()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();

            List<AuthorEntity> authorEntities = new List<AuthorEntity>();

            libraryContextMock
                .Setup(x => x.Authors)
                .ReturnsDbSet(GetFakeAuthorsList());

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            authorEntities = libraryRepository.GetAllAuthors().ToList();

            Assert.IsNotNull(authorEntities);
            Assert.IsTrue(authorEntities.Count == 2);
        }

        [TestMethod]
        public void Test_GetAllGenres_ReturnsAllGenres()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();

            List<GenreEntity> genreEntities = new List<GenreEntity>();

            libraryContextMock
                .Setup(x => x.Genres)
                .ReturnsDbSet(GetFakeGenresList());

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            genreEntities = libraryRepository.GetAllGenres().ToList();

            Assert.IsNotNull(genreEntities);
            Assert.IsTrue(genreEntities.Count == 2);
        }

        [TestMethod]
        public void Test_GetAllPublishers_ReturnsAllPublishers()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();

            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();

            libraryContextMock
                .Setup(x => x.Publishers)
                .ReturnsDbSet(GetFakePublishersList());

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            publisherEntities = libraryRepository.GetAllPublishers().ToList();

            Assert.IsNotNull(publisherEntities);
            Assert.IsTrue(publisherEntities.Count == 2);
        }

        [TestMethod]
        public void Test_GetBookById_WhenInputIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.Empty;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.GetBookById(id);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_GetBookById_WhenInputIsId_ReturnBook()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.NewGuid();
            BookEntity expectedBookEntity = new BookEntity() { Id = id };

            libraryContextMock
                .Setup(x => x.Books.Find(It.IsAny<Guid>()))
                .Returns(expectedBookEntity);

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            BookEntity actualBookEntity = libraryRepository.GetBookById(id);

            Assert.IsNotNull(actualBookEntity);
            Assert.AreSame(expectedBookEntity, actualBookEntity);
        }

        [TestMethod]
        public void Test_GetAuthorById_WhenInputIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.Empty;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.GetAuthorById(id);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_GetAuthorById_WhenInputIsId_ReturnAuthor()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.NewGuid();
            AuthorEntity expectedAuthorEntity = new AuthorEntity() { Id = id };

            libraryContextMock
                .Setup(x => x.Authors.Find(It.IsAny<Guid>()))
                .Returns(expectedAuthorEntity);

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            AuthorEntity actualAuthorEntity = libraryRepository.GetAuthorById(id);

            Assert.IsNotNull(actualAuthorEntity);
            Assert.AreSame(expectedAuthorEntity, actualAuthorEntity);
        }

        [TestMethod]
        public void Test_GetGenreById_WhenInputIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.Empty;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.GetGenreById(id);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_GetGenreById_WhenInputIsId_ReturnGenre()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.NewGuid();
            GenreEntity expectedGenreEntity = new GenreEntity() { Id = id };

            libraryContextMock
                .Setup(x => x.Genres.Find(It.IsAny<Guid>()))
                .Returns(expectedGenreEntity);

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            GenreEntity actualGenreEntity = libraryRepository.GetGenreById(id);

            Assert.IsNotNull(actualGenreEntity);
            Assert.AreSame(expectedGenreEntity, actualGenreEntity);
        }

        [TestMethod]
        public void Test_GetPublisherById_WhenInputIdIsEmpty_ThrowsArgumentException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.Empty;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.GetPublisherById(id);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_GetPublisherById_WhenInputIsId_ReturnPublisher()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Guid id = Guid.NewGuid();
            PublisherEntity expectedPublisherEntity = new PublisherEntity() { Id = id };

            libraryContextMock
                .Setup(x => x.Publishers.Find(It.IsAny<Guid>()))
                .Returns(expectedPublisherEntity);

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            PublisherEntity actualPublisherEntity = libraryRepository.GetPublisherById(id);

            Assert.IsNotNull(actualPublisherEntity);
            Assert.AreSame(expectedPublisherEntity, actualPublisherEntity);
        }

        [TestMethod]
        public void Test_UpdateBook_WhenInputNewBookIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            BookEntity newBookEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.UpdateBook(newBookEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_UpdateBook_WhenInputIsCorrect_UpdateEntity()
        {
            const string ExpectedTitle = "Title";
            const int ExpectedPages = 100; 
            Guid ExpectedId= Guid.NewGuid();
            DateTime ExpectedReleaseDate = new DateTime(1000, 10, 10);

            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            BookEntity newBookEntity = new BookEntity() { Id = ExpectedId, Title = ExpectedTitle, Pages = ExpectedPages, ReleaseDate = ExpectedReleaseDate, Authors = new List<AuthorEntity>(), Genres = new List<GenreEntity>(), Publishers = new List<PublisherEntity>() };
            BookEntity oldBookEntity = new BookEntity() { Id = ExpectedId, Title = string.Empty, Pages = 0, ReleaseDate = DateTime.MinValue };

            List<BookEntity> bookEntities = new List<BookEntity>();
            bookEntities.Add(oldBookEntity);

            libraryContextMock
                .Setup(x => x.Books.Find(It.IsAny<Guid>()))
                .Returns(oldBookEntity);

            libraryContextMock
                .Setup(x => x.Books.Remove(It.IsAny<BookEntity>()))
                .Callback(new Action<BookEntity>(entity =>
                {
                    if(entity == null)
                    {
                        return;
                    }

                    bookEntities.Remove(entity);
                }));

            libraryContextMock
                .Setup(x => x.Books.Add(It.IsAny<BookEntity>()))
                .Callback(new Action<BookEntity>(entity =>
                {
                    if(entity == null)
                    {
                        return;
                    }

                    bookEntities.Add(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.UpdateBook(newBookEntity);

            foreach(BookEntity entity in bookEntities)
            {
                Assert.AreEqual(ExpectedId, entity.Id);
                Assert.AreEqual(ExpectedTitle, entity.Title);
                Assert.AreEqual(ExpectedPages, entity.Pages);
                Assert.AreEqual(ExpectedReleaseDate, entity.ReleaseDate);
                Assert.IsNotNull(entity.Authors);
                Assert.IsNotNull(entity.Genres);
                Assert.IsNotNull(entity.Publishers);
            };
        }

        [TestMethod]
        public void Test_UpdateAuthor_WhenInputNewAuthorIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            AuthorEntity newAuthorEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.UpdateAuthor(newAuthorEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_UpdateAuthor_WhenInputIsCorrect_UpdateEntity()
        {
            const string ExpectedName = "Name";
            Guid ExpectedId = Guid.NewGuid();

            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            AuthorEntity newAuthorEntity = new AuthorEntity() { Id = ExpectedId, Name = ExpectedName, Books = new List<BookEntity>() };
            AuthorEntity oldAuthorEntity = new AuthorEntity() { Id = ExpectedId, Name = string.Empty };

            List<AuthorEntity> authorEntities = new List<AuthorEntity>();
            authorEntities.Add(oldAuthorEntity);

            libraryContextMock
                .Setup(x => x.Authors.Find(It.IsAny<Guid>()))
                .Returns(oldAuthorEntity);

            libraryContextMock
                .Setup(x => x.Authors.Remove(It.IsAny<AuthorEntity>()))
                .Callback(new Action<AuthorEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    authorEntities.Remove(entity);
                }));

            libraryContextMock
                .Setup(x => x.Authors.Add(It.IsAny<AuthorEntity>()))
                .Callback(new Action<AuthorEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    authorEntities.Add(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.UpdateAuthor(newAuthorEntity);

            foreach (AuthorEntity entity in authorEntities)
            {
                Assert.AreEqual(ExpectedId, entity.Id);
                Assert.AreEqual(ExpectedName, entity.Name);
                Assert.IsNotNull(entity.Books);
            };
        }

        [TestMethod]
        public void Test_UpdateGenre_WhenInputNewGenreIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            GenreEntity newGenreEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.UpdateGenre(newGenreEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_UpdateGenre_WhenInputIsCorrect_UpdateEntity()
        {
            const string ExpectedName = "Name";
            Guid ExpectedId = Guid.NewGuid();

            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            GenreEntity newGenreEntity = new GenreEntity() { Id = ExpectedId, Name = ExpectedName, Books = new List<BookEntity>() };
            GenreEntity oldGenreEntity = new GenreEntity() { Id = ExpectedId, Name = string.Empty };

            List<GenreEntity> genreEntities = new List<GenreEntity>();
            genreEntities.Add(oldGenreEntity);

            libraryContextMock
                .Setup(x => x.Genres.Find(It.IsAny<Guid>()))
                .Returns(oldGenreEntity);

            libraryContextMock
                .Setup(x => x.Genres.Remove(It.IsAny<GenreEntity>()))
                .Callback(new Action<GenreEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    genreEntities.Remove(entity);
                }));

            libraryContextMock
                .Setup(x => x.Genres.Add(It.IsAny<GenreEntity>()))
                .Callback(new Action<GenreEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    genreEntities.Add(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.UpdateGenre(newGenreEntity);

            foreach (GenreEntity entity in genreEntities)
            {
                Assert.AreEqual(ExpectedId, entity.Id);
                Assert.AreEqual(ExpectedName, entity.Name);
                Assert.IsNotNull(entity.Books);
            };
        }

        [TestMethod]
        public void Test_UpdatePublisher_WhenInputNewPublisherIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            PublisherEntity newPublisherEntity = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.UpdatePublisher(newPublisherEntity);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_UpdatePublisher_WhenInputIsCorrect_UpdateEntity()
        {
            const string ExpectedName = "Name";
            Guid ExpectedId = Guid.NewGuid();

            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            PublisherEntity newPublisherEntity = new PublisherEntity() { Id = ExpectedId, Name = ExpectedName, Books = new List<BookEntity>() };
            PublisherEntity oldPublisherEntity = new PublisherEntity() { Id = ExpectedId, Name = string.Empty };

            List<PublisherEntity> publisherEntities = new List<PublisherEntity>();
            publisherEntities.Add(oldPublisherEntity);

            libraryContextMock
                .Setup(x => x.Publishers.Find(It.IsAny<Guid>()))
                .Returns(oldPublisherEntity);

            libraryContextMock
                .Setup(x => x.Publishers.Remove(It.IsAny<PublisherEntity>()))
                .Callback(new Action<PublisherEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    publisherEntities.Remove(entity);
                }));

            libraryContextMock
                .Setup(x => x.Publishers.Add(It.IsAny<PublisherEntity>()))
                .Callback(new Action<PublisherEntity>(entity =>
                {
                    if (entity == null)
                    {
                        return;
                    }

                    publisherEntities.Add(entity);
                }));

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            libraryRepository.UpdatePublisher(newPublisherEntity);

            foreach (PublisherEntity entity in publisherEntities)
            {
                Assert.AreEqual(ExpectedId, entity.Id);
                Assert.AreEqual(ExpectedName, entity.Name);
                Assert.IsNotNull(entity.Books);
            };
        }

        [TestMethod]
        public void Test_FindBooks_WhenInputPredicateIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Func<BookEntity, bool> predicate = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.FindBooks(predicate);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_FindBooks_WhenInputPredicateIsCorrect_ReturnBooks()
        {
            const string ExpectedTitle = "Title1";
            const int ExpectedPages = 100;
            DateTime expectedReleaseDate = DateTime.MaxValue;

            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Func<BookEntity, bool> predicate = x => x.Title == ExpectedTitle;
            List<BookEntity> bookEntities = GetFakeBooksList();
            List<BookEntity> actualBookEntities;

            libraryContextMock
                .Setup(x => x.Books)
                .ReturnsDbSet(bookEntities);

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            actualBookEntities = libraryRepository.FindBooks(predicate).ToList();

            Assert.IsTrue(actualBookEntities.Count != 0);

            foreach (BookEntity bookEntity in actualBookEntities)
            {
                Assert.AreEqual(ExpectedTitle, bookEntity.Title);
                Assert.AreEqual(ExpectedPages, bookEntity.Pages);
                Assert.AreEqual(expectedReleaseDate, bookEntity.ReleaseDate);
                Assert.IsNotNull(bookEntity.Authors);
                Assert.IsNotNull(bookEntity.Genres);
                Assert.IsNotNull(bookEntity.Publishers);
            }
        }

        [TestMethod]
        public void Test_FindAuthors_WhenInputPredicateIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Func<AuthorEntity, bool> predicate = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.FindAuthors(predicate);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_FindAuthors_WhenInputPredicateIsCorrect_ReturnAuthors()
        {
            const string ExpectedName = "Author1";

            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Func<AuthorEntity, bool> predicate = x => x.Name == ExpectedName;
            List<AuthorEntity> authorEntities = GetFakeAuthorsList();
            List<AuthorEntity> actualAuthorEntities;

            libraryContextMock
                .Setup(x => x.Authors)
                .ReturnsDbSet(authorEntities);

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            actualAuthorEntities = libraryRepository.FindAuthors(predicate).ToList();

            Assert.IsTrue(actualAuthorEntities.Count != 0);

            foreach (AuthorEntity authorEntity in actualAuthorEntities)
            {
                Assert.AreEqual(ExpectedName, authorEntity.Name);
                Assert.IsNotNull(authorEntity.Books);
            }
        }

        [TestMethod]
        public void Test_FindGenres_WhenInputPredicateIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Func<GenreEntity, bool> predicate = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.FindGenres(predicate);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_FindGenres_WhenInputPredicateIsCorrect_ReturnGenres()
        {
            const string ExpectedName = "Genre1";

            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Func<GenreEntity, bool> predicate = x => x.Name == ExpectedName;
            List<GenreEntity> genreEntities = GetFakeGenresList();
            List<GenreEntity> actualGenreEntities;

            libraryContextMock
                .Setup(x => x.Genres)
                .ReturnsDbSet(genreEntities);

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            actualGenreEntities = libraryRepository.FindGenres(predicate).ToList();

            Assert.IsTrue(actualGenreEntities.Count != 0);

            foreach (GenreEntity genreEntity in actualGenreEntities)
            {
                Assert.AreEqual(ExpectedName, genreEntity.Name);
                Assert.IsNotNull(genreEntity.Books);
            }
        }

        [TestMethod]
        public void Test_FindPublishers_WhenInputPredicateIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Func<PublisherEntity, bool> predicate = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.FindPublishers(predicate);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_FindPublishers_WhenInputPredicateIsCorrect_ReturnPublishers()
        {
            const string ExpectedName = "Publisher1";

            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Func<PublisherEntity, bool> predicate = x => x.Name == ExpectedName;
            List<PublisherEntity> publisherEntities = GetFakePublishersList();
            List<PublisherEntity> actualPublishersEntities;

            libraryContextMock
                .Setup(x => x.Publishers)
                .ReturnsDbSet(publisherEntities);

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            actualPublishersEntities = libraryRepository.FindPublishers(predicate).ToList();

            Assert.IsTrue(actualPublishersEntities.Count != 0);

            foreach (PublisherEntity publisherEntity in actualPublishersEntities)
            {
                Assert.AreEqual(ExpectedName, publisherEntity.Name);
                Assert.IsNotNull(publisherEntity.Books);
            }
        }

        [TestMethod]
        public void Test_FindBooks_WhenInputFilterIsNull_ThrowsArgumentNullException()
        {
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Filter filter = null;

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            Action action = () => libraryRepository.FindBooks(filter);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_FindBooks_WhenInputFilterIsCorrect_ThrowsArgumentNullException()
        {
            const string ExpectedTitle = "Title1";
            const int ExpectedPages = 100;
            DateTime expectedReleaseDate = DateTime.MaxValue;
            Mock<LibraryContext> libraryContextMock = new Mock<LibraryContext>();
            Filter filter = new Filter("Title1", null, null, null, "50", "150", null, "10.10.1000");

            libraryContextMock
                .Setup(x => x.Books)
                .ReturnsDbSet(GetFakeBooksList());

            LibraryRepository libraryRepository = new LibraryRepository(libraryContextMock.Object);

            List<BookEntity> bookEntities = libraryRepository.FindBooks(filter).ToList();

            Assert.IsTrue(bookEntities.Count != 0);

            foreach (BookEntity bookEntity in bookEntities)
            {
                Assert.AreEqual(ExpectedTitle, bookEntity.Title);
                Assert.AreEqual(ExpectedPages, bookEntity.Pages);
                Assert.AreEqual(expectedReleaseDate, bookEntity.ReleaseDate);
                Assert.IsNotNull(bookEntity.Authors);
                Assert.IsNotNull(bookEntity.Genres);
                Assert.IsNotNull(bookEntity.Publishers);
            }
        }

        private static List<BookEntity> GetFakeBooksList()
        {
            return new List<BookEntity>
            {
                new BookEntity
                {
                    Title = "Title1",
                    Pages = 100,
                    ReleaseDate = DateTime.MaxValue,
                    Authors = new List<AuthorEntity>(),
                    Genres = new List<GenreEntity>(),
                    Publishers = new List<PublisherEntity>()
                },

                new BookEntity
                {
                    Title = "Title2",
                    Pages = 200,
                    ReleaseDate = DateTime.MinValue,
                    Authors = new List<AuthorEntity>(),
                    Genres = new List<GenreEntity>(),
                    Publishers = new List<PublisherEntity>()
                }
            };
        }

        private static List<AuthorEntity> GetFakeAuthorsList()
        {
            return new List<AuthorEntity>
            {
                new AuthorEntity
                {
                    Name = "Author1",
                    Books = new List<BookEntity>()
                },

                new AuthorEntity
                {
                    Name = "Author2",
                    Books = new List<BookEntity>()
                }
            };
        }

        private static List<GenreEntity> GetFakeGenresList()
        {
            return new List<GenreEntity>
            {
                new GenreEntity
                {
                    Name = "Genre1",
                    Books = new List<BookEntity>()
                },

                new GenreEntity
                {
                    Name = "Genre2",
                    Books = new List<BookEntity>()
                }
            };
        }

        private static List<PublisherEntity> GetFakePublishersList()
        {
            return new List<PublisherEntity>
            {
                new PublisherEntity
                {
                    Name = "Publisher1",
                    Books = new List<BookEntity>()
                },

                new PublisherEntity
                {
                    Name = "Publisher2",
                    Books = new List<BookEntity>()
                }
            };
        }
    }
}