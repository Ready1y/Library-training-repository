using Books.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class BookEntityTests
    {
        [TestMethod]
        public void Test_GetId_ReturnsId()
        {
            Guid expectedId = new Guid();

            BookEntity book = new BookEntity() { Id = expectedId };

            Guid actualId = book.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void Test_SetId_SetValueToId()
        {
            Guid startId = Guid.Empty;
            Guid expectedId = new Guid();

            BookEntity book = new BookEntity() { Id = startId };

            book.Id = expectedId;

            Assert.AreEqual(expectedId, book.Id);
        }

        [TestMethod]
        public void Test_GetTitle_ReturnsTitle()
        {
            const string expectedName = "Book";

            BookEntity book = new BookEntity() { Title = expectedName };

            string actualName = book.Title;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void Test_SetTitle_SetValueToTitle()
        {
            const string startName = "name";
            const string expectedName = "Book";

            BookEntity book = new BookEntity() { Title = startName };

            book.Title = expectedName;

            Assert.AreEqual(expectedName, book.Title);
        }

        [TestMethod]
        public void Test_GetPages_ReturnsPages()
        {
            const int expectedPages = 100;

            BookEntity book = new BookEntity() { Pages = expectedPages };

            int actualPages = book.Pages;

            Assert.AreEqual(expectedPages, actualPages);
        }

        [TestMethod]
        public void Test_SetPages_SetValueToPages()
        {
            const int startPages = 10;
            const int expectedPages = 100;

            BookEntity book = new BookEntity() { Pages = startPages };

            book.Pages = expectedPages;

            Assert.AreEqual(expectedPages, book.Pages);
        }

        [TestMethod]
        public void Test_GetReleaseDate_ReturnsReleaseDate()
        {
            DateTime expectedReleaseDate = DateTime.MaxValue;

            BookEntity book = new BookEntity() { ReleaseDate = expectedReleaseDate };

            DateTime actualReleaseDate = book.ReleaseDate;

            Assert.AreEqual(expectedReleaseDate, actualReleaseDate);
        }

        [TestMethod]
        public void Test_SetReleaseDate_SetValueToReleaseDate()
        {
            DateTime startReleaseDate = DateTime.MinValue;
            DateTime expectedReleaseDate = DateTime.MaxValue;

            BookEntity book = new BookEntity() { ReleaseDate = startReleaseDate };

            book.ReleaseDate = expectedReleaseDate;

            Assert.AreEqual(expectedReleaseDate, book.ReleaseDate);
        }

        [TestMethod]
        public void Test_GetAuthors_ReturnsAuthors()
        {
            List<AuthorEntity> expectedAuthorEntities = new List<AuthorEntity>();
            expectedAuthorEntities.Add(new AuthorEntity() { Id = Guid.NewGuid() });
            expectedAuthorEntities.Add(new AuthorEntity() { Id = Guid.NewGuid() });

            BookEntity book = new BookEntity();
            book.Authors = expectedAuthorEntities;

            List<AuthorEntity> actualAuthorEntities = new List<AuthorEntity>();

            actualAuthorEntities = book.Authors.ToList();

            foreach (AuthorEntity authorEntity in actualAuthorEntities)
            {
                Assert.IsTrue(expectedAuthorEntities.Contains(authorEntity));
            }
        }

        [TestMethod]
        public void Test_SetAuthors_SetValueToAuthors()
        {
            List<AuthorEntity> expectedAuthorEntities = new List<AuthorEntity>();
            expectedAuthorEntities.Add(new AuthorEntity() { Id = Guid.NewGuid() });
            expectedAuthorEntities.Add(new AuthorEntity() { Id = Guid.NewGuid() });

            BookEntity book = new BookEntity();
            book.Authors = expectedAuthorEntities;

            foreach (AuthorEntity authorEntity in book.Authors)
            {
                Assert.IsTrue(expectedAuthorEntities.Contains(authorEntity));
            }
        }

        [TestMethod]
        public void Test_GetGenres_ReturnsGenres()
        {
            List<GenreEntity> expectedGenreEntities = new List<GenreEntity>();
            expectedGenreEntities.Add(new GenreEntity() { Id = Guid.NewGuid() });
            expectedGenreEntities.Add(new GenreEntity() { Id = Guid.NewGuid() });

            BookEntity book = new BookEntity();
            book.Genres = expectedGenreEntities;

            List<GenreEntity> actualGenreEntities = new List<GenreEntity>();

            actualGenreEntities = book.Genres.ToList();

            foreach (GenreEntity genreEntity in actualGenreEntities)
            {
                Assert.IsTrue(expectedGenreEntities.Contains(genreEntity));
            }
        }

        [TestMethod]
        public void Test_SetGenres_SetValueToGenres()
        {
            List<GenreEntity> expectedGenreEntities = new List<GenreEntity>();
            expectedGenreEntities.Add(new GenreEntity() { Id = Guid.NewGuid() });
            expectedGenreEntities.Add(new GenreEntity() { Id = Guid.NewGuid() });

            BookEntity book = new BookEntity();
            book.Genres = expectedGenreEntities;

            foreach (GenreEntity genreEntity in book.Genres)
            {
                Assert.IsTrue(expectedGenreEntities.Contains(genreEntity));
            }
        }

        [TestMethod]
        public void Test_GetPublishers_ReturnsPublishers()
        {
            List<PublisherEntity> expectedPublisherEntities = new List<PublisherEntity>();
            expectedPublisherEntities.Add(new PublisherEntity() { Id = Guid.NewGuid() });
            expectedPublisherEntities.Add(new PublisherEntity() { Id = Guid.NewGuid() });

            BookEntity book = new BookEntity();
            book.Publishers = expectedPublisherEntities;

            List<PublisherEntity> actualPublisherEntities = new List<PublisherEntity>();

            actualPublisherEntities = book.Publishers.ToList();

            foreach (PublisherEntity publisherEntity in actualPublisherEntities)
            {
                Assert.IsTrue(expectedPublisherEntities.Contains(publisherEntity));
            }
        }

        [TestMethod]
        public void Test_SetPublishers_SetValueToPublishers()
        {
            List<PublisherEntity> expectedPublisherEntities = new List<PublisherEntity>();
            expectedPublisherEntities.Add(new PublisherEntity() { Id = Guid.NewGuid() });
            expectedPublisherEntities.Add(new PublisherEntity() { Id = Guid.NewGuid() });

            BookEntity book = new BookEntity();
            book.Publishers = expectedPublisherEntities;

            foreach (PublisherEntity publisherEntity in book.Publishers)
            {
                Assert.IsTrue(expectedPublisherEntities.Contains(publisherEntity));
            }
        }

        [TestMethod]
        public void Test_GetHashCode_WhenInputIsSameObjects_ReturnsSameValue()
        {
            BookEntity book1 = new BookEntity { Id = Guid.NewGuid(), Title = "Book", Pages = 123, ReleaseDate = DateTime.MinValue };
            BookEntity book2 = new BookEntity { Id = book1.Id, Title = book1.Title, Pages = book1.Pages, ReleaseDate = book1.ReleaseDate };

            int hashCode1 = book1.GetHashCode();
            int hashCode2 = book2.GetHashCode();

            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Test_GetHashCode_WhenInputIsDifferentObjects_ReturnsDifferentValue()
        {
            BookEntity book1 = new BookEntity { Id = Guid.NewGuid(), Title = "Book1", Pages = 123, ReleaseDate = DateTime.MinValue };
            BookEntity book2 = new BookEntity { Id = Guid.NewGuid(), Title = "Book2", Pages = 321, ReleaseDate = DateTime.MaxValue };

            int hashCode1 = book1.GetHashCode();
            int hashCode2 = book2.GetHashCode();

            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsEqualObject_ReturnsTrue()
        {
            BookEntity book1 = new BookEntity { Id = Guid.NewGuid(), Title = "Book1", Pages = 123, ReleaseDate = DateTime.MinValue };
            BookEntity book2 = new BookEntity { Id = book1.Id, Title = book1.Title, Pages = book1.Pages, ReleaseDate = book1.ReleaseDate };

            bool result = book1.Equals((object)book2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsDifferentObjects_ReturnsFalse()
        {
            BookEntity book1 = new BookEntity { Id = Guid.NewGuid(), Title = "Book1", Pages = 123, ReleaseDate = DateTime.MinValue };
            BookEntity book2 = new BookEntity { Id = Guid.NewGuid(), Title = "Book2", Pages = 321, ReleaseDate = DateTime.MaxValue };

            bool result = book1.Equals((object)book2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsEqualBookEntities_ReturnsTrue()
        {
            BookEntity book1 = new BookEntity { Id = Guid.NewGuid(), Title = "Book1", Pages = 123, ReleaseDate = DateTime.MinValue };
            BookEntity book2 = new BookEntity { Id = book1.Id, Title = book1.Title, Pages = book1.Pages, ReleaseDate = book1.ReleaseDate };

            bool result = book1.Equals(book2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsDifferentBookEntities_ReturnsFalse()
        {
            BookEntity book1 = new BookEntity { Id = Guid.NewGuid(), Title = "Book1", Pages = 123, ReleaseDate = DateTime.MinValue };
            BookEntity book2 = new BookEntity { Id = Guid.NewGuid(), Title = "Book2", Pages = 321, ReleaseDate = DateTime.MaxValue };

            bool result = book1.Equals(book2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsNull_ReturnsFalse()
        {
            BookEntity book1 = new BookEntity { Id = Guid.NewGuid(), Title = "Book1", Pages = 123, ReleaseDate = DateTime.MinValue };
            BookEntity book2 = null;

            bool result = book1.Equals(book2);

            Assert.IsFalse(result);
        }
    }
}