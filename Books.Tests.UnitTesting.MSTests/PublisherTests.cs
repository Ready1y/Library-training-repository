using Books.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class PublisherTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsTwoParameters_ReturnsAuthorObject()
        {
            Guid expectedId = new Guid();
            const string expectedName = "Publisher";

            Publisher publisher = new Publisher(expectedId, expectedName);

            Assert.AreEqual(expectedId, publisher.Id);
            Assert.AreEqual(expectedName, publisher.Name);
        }

        [TestMethod]
        public void Test_GetId_ReturnsId()
        {
            Guid expectedId = new Guid();
            const string expectedName = "Publisher";

            Publisher publisher = new Publisher(expectedId, expectedName);

            Guid actualId = publisher.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [TestMethod]
        public void Test_SetId_SetValueToId()
        {
            Guid startId = Guid.Empty;
            Guid expectedId = new Guid();
            const string expectedName = "Publisher";

            Publisher publisher = new Publisher(startId, expectedName);

            publisher.Id = expectedId;

            Assert.AreEqual(expectedId, publisher.Id);
        }

        [TestMethod]
        public void Test_GetName_ReturnsName()
        {
            Guid Id = new Guid();
            const string expectedName = "Publisher";

            Publisher publisher = new Publisher(Id, expectedName);

            string actualName = publisher.Name;

            Assert.AreEqual(expectedName, actualName);
        }

        [TestMethod]
        public void Test_SetName_SetValueToName()
        {
            Guid Id = new Guid();
            const string startName = "name";
            const string expectedName = "Publisher";

            Publisher publisher = new Publisher(Id, startName);

            publisher.Name = expectedName;

            Assert.AreEqual(expectedName, publisher.Name);
        }
    }
}