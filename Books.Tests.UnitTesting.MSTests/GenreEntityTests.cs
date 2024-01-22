using Books.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class GenreEntityTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsTwoParameters_ReturnsAuthorObject()
        {
            Guid expectedId = new Guid();
            const string expectedName = "Genre";

            GenreEntity genre = new GenreEntity(expectedId, expectedName);

            Assert.AreEqual(expectedId, genre.Id);
            Assert.AreEqual(expectedName, genre.Name);
        }

        [TestMethod]
        public void Test_GetId_ReturnsId()
        {
            Guid expectedId = new Guid();
            const string expectedName = "Genre";

            GenreEntity genre = new GenreEntity(expectedId, expectedName);

            Guid actualId = genre.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void Test_SetId_SetValueToId()
        {
            Guid startId = Guid.Empty;
            Guid expectedId = new Guid();
            const string expectedName = "Genre";

            GenreEntity genre = new GenreEntity(startId, expectedName);

            genre.Id = expectedId;

            Assert.AreEqual(expectedId, genre.Id);
        }

        [TestMethod]
        public void Test_GetName_ReturnsName()
        {
            Guid Id = new Guid();
            const string expectedName = "Genre";

            GenreEntity genre = new GenreEntity(Id, expectedName);

            string actualName = genre.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void Test_SetName_SetValueToName()
        {
            Guid Id = new Guid();
            const string startName = "name";
            const string expectedName = "Genre";

            GenreEntity genre = new GenreEntity(Id, startName);

            genre.Name = expectedName;

            Assert.AreEqual(expectedName, genre.Name);
        }
    }
}