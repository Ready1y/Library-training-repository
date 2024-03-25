using Books.Entities;
using Books.Mappers;
using Books.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class PublisherMapperTests
    {
        [TestMethod]
        public void Test_GetEntities_WhenInputBookModelsAreNull_ThrowsArgumentNullException()
        {
            BookModel[] bookModels = null;

            Action action = () => PublisherMapper.GetEntities(bookModels);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_GetEntities_WhenInputAreCorrect_ReturnsListOfPublisherEntities()
        {
            const string PublisherName = "Publisher";

            BookModel[] bookModels = new BookModel[1];
            bookModels[0] = new BookModel() { Publisher = PublisherName };

            IReadOnlyList<PublisherEntity> publisherEntities = PublisherMapper.GetEntities(bookModels);

            foreach (PublisherEntity publisherEntity in publisherEntities)
            {
                Assert.IsTrue(publisherEntity.Id != Guid.Empty);
                Assert.IsTrue(publisherEntity.Name == PublisherName);
                Assert.IsNotNull(publisherEntity.Books);
            }
        }
    }
}
