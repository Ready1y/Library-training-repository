using Books.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class PublisherEntityTests
    {
        [TestMethod]
        public void Test_GetId_ReturnsId()
        {
            Guid expectedId = new Guid();

            PublisherEntity publisher = new PublisherEntity() { Id = expectedId };

            Guid actualId = publisher.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void Test_SetId_SetValueToId()
        {
            Guid startId = Guid.Empty;
            Guid expectedId = new Guid();

            PublisherEntity publisher = new PublisherEntity() { Id = startId };

            publisher.Id = expectedId;

            Assert.AreEqual(expectedId, publisher.Id);
        }

        [TestMethod]
        public void Test_GetName_ReturnsName()
        {
            const string expectedName = "Author";

            PublisherEntity publisher = new PublisherEntity() { Name = expectedName };

            string actualName = publisher.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void Test_SetName_SetValueToName()
        {
            const string startName = "name";
            const string expectedName = "Author";

            PublisherEntity publisher = new PublisherEntity() { Name = startName };

            publisher.Name = expectedName;

            Assert.AreEqual(expectedName, publisher.Name);
        }

        [TestMethod]
        public void Test_GetBooks_ReturnsBooks()
        {
            List<BookEntity> expectedbookEntities = new List<BookEntity>();
            expectedbookEntities.Add(new BookEntity() { Id = Guid.NewGuid() });
            expectedbookEntities.Add(new BookEntity() { Id = Guid.NewGuid() });

            PublisherEntity publisher = new PublisherEntity();
            publisher.Books = expectedbookEntities;

            List<BookEntity> actualbookEntities = new List<BookEntity>();

            actualbookEntities = publisher.Books.ToList();

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

            PublisherEntity publisher = new PublisherEntity();
            publisher.Books = expectedbookEntities;

            foreach (BookEntity bookEntity in publisher.Books)
            {
                Assert.IsTrue(expectedbookEntities.Contains(bookEntity));
            }
        }

        [TestMethod]
        public void Test_GetHashCode_WhenInputIsSameObjects_ReturnsSameValue()
        {
            PublisherEntity publisher1 = new PublisherEntity { Id = Guid.NewGuid(), Name = "Name" };
            PublisherEntity publisher2 = new PublisherEntity { Id = publisher1.Id, Name = publisher1.Name };

            int hashCode1 = publisher1.GetHashCode();
            int hashCode2 = publisher2.GetHashCode();

            Assert.AreEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Test_GetHashCode_WhenInputIsDifferentObjects_ReturnsDifferentValue()
        {
            PublisherEntity publisher1 = new PublisherEntity { Id = Guid.NewGuid(), Name = "Name" };
            PublisherEntity publisher2 = new PublisherEntity { Id = Guid.NewGuid(), Name = publisher1.Name };

            int hashCode1 = publisher1.GetHashCode();
            int hashCode2 = publisher2.GetHashCode();

            Assert.AreNotEqual(hashCode1, hashCode2);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsEqualObject_ReturnsTrue()
        {
            PublisherEntity publisher1 = new PublisherEntity { Id = Guid.NewGuid(), Name = "Name" };
            PublisherEntity publisher2 = new PublisherEntity { Id = publisher1.Id, Name = publisher1.Name };

            bool result = publisher1.Equals((object)publisher2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsDifferentObjects_ReturnsFalse()
        {
            PublisherEntity publisher1 = new PublisherEntity { Id = Guid.NewGuid(), Name = "Name" };
            PublisherEntity publisher2 = new PublisherEntity { Id = Guid.NewGuid(), Name = publisher1.Name };

            bool result = publisher1.Equals((object)publisher2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsEqualPublisherEntities_ReturnsTrue()
        {
            PublisherEntity publisher1 = new PublisherEntity { Id = Guid.NewGuid(), Name = "Name" };
            PublisherEntity publisher2 = new PublisherEntity { Id = publisher1.Id, Name = publisher1.Name };

            bool result = publisher1.Equals(publisher2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsDifferentPublisherEntities_ReturnsFalse()
        {
            PublisherEntity publisher1 = new PublisherEntity { Id = Guid.NewGuid(), Name = "Name" };
            PublisherEntity publisher2 = new PublisherEntity { Id = Guid.NewGuid(), Name = publisher1.Name };

            bool result = publisher1.Equals(publisher2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Equals_WhenInputIsNull_ReturnsFalse()
        {
            PublisherEntity publisher1 = new PublisherEntity { Id = Guid.NewGuid(), Name = "Name" };
            PublisherEntity publisher2 = null;

            bool result = publisher1.Equals(publisher2);

            Assert.IsFalse(result);
        }
    }
}