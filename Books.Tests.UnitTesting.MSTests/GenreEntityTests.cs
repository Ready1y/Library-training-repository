using Books.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class GenreEntityTests
    {
        [TestMethod]
        public void Test_GetId_ReturnsId()
        {
            Guid expectedId = new Guid();

            GenreEntity genre = new GenreEntity() { Id = expectedId };

            Guid actualId = genre.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void Test_SetId_SetValueToId()
        {
            Guid startId = Guid.Empty;
            Guid expectedId = new Guid();

            GenreEntity genre = new GenreEntity() { Id = startId };

            genre.Id = expectedId;

            Assert.AreEqual(expectedId, genre.Id);
        }

        [TestMethod]
        public void Test_GetName_ReturnsName()
        {
            const string expectedName = "Author";

            GenreEntity genre = new GenreEntity() { Name = expectedName };

            string actualName = genre.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void Test_SetName_SetValueToName()
        {
            const string startName = "name";
            const string expectedName = "Author";

            GenreEntity genre = new GenreEntity() { Name = startName };

            genre.Name = expectedName;

            Assert.AreEqual(expectedName, genre.Name);
        }

        [TestMethod]
        public void Test_GetBooks_ReturnsBooks()
        {
            List<BookEntity> expectedbookEntities = new List<BookEntity>();
            expectedbookEntities.Add(new BookEntity() { Id = Guid.NewGuid() });
            expectedbookEntities.Add(new BookEntity() { Id = Guid.NewGuid() });

            GenreEntity genre = new GenreEntity();
            genre.Books = expectedbookEntities;

            List<BookEntity> actualbookEntities = new List<BookEntity>();

            actualbookEntities = genre.Books.ToList();

            foreach (BookEntity bookEntity in actualbookEntities)
            {
                Assert.IsTrue(expectedbookEntities.Contains(bookEntity));
            }
        }

        [TestMethod]
        public void Test_SetBooks_SetValueToBooks()
        {
            List<BookEntity> expectedbookEntities = new List<BookEntity>();
            expectedbookEntities.Add(new BookEntity() { Id = Guid.NewGuid() });
            expectedbookEntities.Add(new BookEntity() { Id = Guid.NewGuid() });

            GenreEntity genre = new GenreEntity();
            genre.Books = expectedbookEntities;

            foreach (BookEntity bookEntity in genre.Books)
            {
                Assert.IsTrue(expectedbookEntities.Contains(bookEntity));
            }
        }

        [TestMethod]
        public void Test_GetHashCode_WhenInputIsSameObjects_ReturnsSameValue()
        {
            GenreEntity genre1 = new GenreEntity { Id = Guid.NewGuid(), Name = "Name" };
            GenreEntity genre2 = new GenreEntity { Id = genre1.Id, Name = genre1.Name };

            int hashCode1 = genre1.GetHashCode();
            int hashCode2 = genre2.GetHashCode();

            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Test_GetHashCode_WhenInputIsDifferentObjects_ReturnsDifferentValue()
        {
            GenreEntity genre1 = new GenreEntity { Id = Guid.NewGuid(), Name = "Name" };
            GenreEntity genre2 = new GenreEntity { Id = Guid.NewGuid(), Name = genre1.Name };

            int hashCode1 = genre1.GetHashCode();
            int hashCode2 = genre2.GetHashCode();

            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsEqualObject_ReturnsTrue()
        {
            GenreEntity genre1 = new GenreEntity { Id = Guid.NewGuid(), Name = "Name" };
            GenreEntity genre2 = new GenreEntity { Id = genre1.Id, Name = genre1.Name };

            bool result = genre1.Equals((object)genre2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsDifferentObjects_ReturnsFalse()
        {
            GenreEntity genre1 = new GenreEntity { Id = Guid.NewGuid(), Name = "Name" };
            GenreEntity genre2 = new GenreEntity { Id = Guid.NewGuid(), Name = genre1.Name };

            bool result = genre1.Equals((object)genre2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsEqualGenreEntities_ReturnsTrue()
        {
            GenreEntity genre1 = new GenreEntity { Id = Guid.NewGuid(), Name = "Name" };
            GenreEntity genre2 = new GenreEntity { Id = genre1.Id, Name = genre1.Name };

            bool result = genre1.Equals(genre2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsDifferentGenreEntities_ReturnsFalse()
        {
            GenreEntity genre1 = new GenreEntity { Id = Guid.NewGuid(), Name = "Name" };
            GenreEntity genre2 = new GenreEntity { Id = Guid.NewGuid(), Name = genre1.Name };

            bool result = genre1.Equals(genre2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsNull_ReturnsFalse()
        {
            GenreEntity genre1 = new GenreEntity { Id = Guid.NewGuid(), Name = "Name" };
            GenreEntity genre2 = null;

            bool result = genre1.Equals(genre2);

            Assert.IsFalse(result);
        }
    }
}