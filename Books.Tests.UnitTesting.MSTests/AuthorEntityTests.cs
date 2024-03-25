using Books.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class AuthorEntityTests
    {
        [TestMethod]
        public void Test_GetId_ReturnsId()
        {
            Guid expectedId = new Guid();

            AuthorEntity author = new AuthorEntity() { Id = expectedId };

            Guid actualId = author.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void Test_SetId_SetValueToId()
        {
            Guid startId = Guid.Empty;
            Guid expectedId = new Guid();

            AuthorEntity author = new AuthorEntity() { Id = startId };

            author.Id = expectedId;

            Assert.AreEqual(expectedId, author.Id);
        }

        [TestMethod]
        public void Test_GetName_ReturnsName()
        {
            const string expectedName = "Author";

            AuthorEntity author = new AuthorEntity() { Name = expectedName };

            string actualName = author.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void Test_SetName_SetValueToName()
        {
            const string startName = "name";
            const string expectedName = "Author";

            AuthorEntity author = new AuthorEntity() { Name = startName };

            author.Name = expectedName;

            Assert.AreEqual(expectedName, author.Name);
        }

        [TestMethod]
        public void Test_GetBooks_ReturnsBooks()
        {
            List<BookEntity> expectedbookEntities = new List<BookEntity>();
            expectedbookEntities.Add(new BookEntity() { Id = Guid.NewGuid() });
            expectedbookEntities.Add(new BookEntity() { Id = Guid.NewGuid() });

            AuthorEntity author = new AuthorEntity();
            author.Books = expectedbookEntities;

            List<BookEntity> actualbookEntities = new List<BookEntity>();

            actualbookEntities = author.Books.ToList();

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

            AuthorEntity author = new AuthorEntity();
            author.Books = expectedbookEntities;

            foreach (BookEntity bookEntity in author.Books)
            {
                Assert.IsTrue(expectedbookEntities.Contains(bookEntity));
            }
        }

        [TestMethod]
        public void Test_GetHashCode_WhenInputIsSameObjects_ReturnsSameValue()
        {
            AuthorEntity author1 = new AuthorEntity { Id = Guid.NewGuid(), Name = "Name" };
            AuthorEntity author2 = new AuthorEntity { Id = author1.Id, Name = author1.Name };

            int hashCode1 = author1.GetHashCode();
            int hashCode2 = author2.GetHashCode();

            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Test_GetHashCode_WhenInputIsDifferentObjects_ReturnsDifferentValue()
        {
            AuthorEntity author1 = new AuthorEntity { Id = Guid.NewGuid(), Name = "Name" };
            AuthorEntity author2 = new AuthorEntity { Id = Guid.NewGuid(), Name = author1.Name };

            int hashCode1 = author1.GetHashCode();
            int hashCode2 = author2.GetHashCode();

            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsEqualObject_ReturnsTrue()
        {
            AuthorEntity author1 = new AuthorEntity { Id = Guid.NewGuid(), Name = "Name" };
            AuthorEntity author2 = new AuthorEntity { Id = author1.Id, Name = author1.Name };

            bool result = author1.Equals((object)author2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsDifferentObjects_ReturnsFalse()
        {
            AuthorEntity author1 = new AuthorEntity { Id = Guid.NewGuid(), Name = "Name" };
            AuthorEntity author2 = new AuthorEntity { Id = Guid.NewGuid(), Name = author1.Name };

            bool result = author1.Equals((object)author2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsEqualAuthorEntities_ReturnsTrue()
        {
            AuthorEntity author1 = new AuthorEntity { Id = Guid.NewGuid(), Name = "Name" };
            AuthorEntity author2 = new AuthorEntity { Id = author1.Id, Name = author1.Name };

            bool result = author1.Equals(author2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsDifferentAuthorEntities_ReturnsFalse()
        {
            AuthorEntity author1 = new AuthorEntity { Id = Guid.NewGuid(), Name = "Name" };
            AuthorEntity author2 = new AuthorEntity { Id = Guid.NewGuid(), Name = author1.Name };

            bool result = author1.Equals(author2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsNull_ReturnsFalse()
        {
            AuthorEntity author1 = new AuthorEntity { Id = Guid.NewGuid(), Name = "Name" };
            AuthorEntity author2 = null;

            bool result = author1.Equals(author2);

            Assert.IsFalse(result);
        }
    }
}