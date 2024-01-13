using Books.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsTwoParameters_ReturnsAuthorObject()
        {
            Guid expectedId = new Guid();
            const string expectedName = "Author";

            Author author = new Author(expectedId, expectedName);

            Assert.AreEqual(expectedId, author.Id);
            Assert.AreEqual(expectedName, author.Name);
        }

        [TestMethod]
        public void Test_GetId_ReturnsId()
        {
            Guid expectedId = new Guid();
            const string expectedName = "Author";

            Author author = new Author(expectedId, expectedName);

            Guid actualId = author.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void Test_SetId_SetValueToId()
        {
            Guid startId = Guid.Empty;
            Guid expectedId = new Guid();
            const string expectedName = "Author";

            Author author = new Author(startId, expectedName);

            author.Id = expectedId;

            Assert.AreEqual(expectedId, author.Id);
        }

        [TestMethod]
        public void Test_GetName_ReturnsName()
        {
            Guid Id = new Guid();
            const string expectedName = "Author";

            Author author = new Author(Id, expectedName);

            string actualName = author.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void Test_SetName_SetValueToName()
        {
            Guid Id = new Guid();
            const string startName = "name";
            const string expectedName = "Author";

            Author author = new Author(Id, startName);

            author.Name = expectedName;

            Assert.AreEqual(expectedName, author.Name);
        }
    }
}