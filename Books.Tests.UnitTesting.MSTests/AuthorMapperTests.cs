using Books.Entities;
using Books.Mappers;
using Books.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class AuthorMapperTests
    {
        [TestMethod]
        public void Test_GetEntities_WhenInputBookModelsAreNull_ThrowsArgumentNullException()
        {
            BookModel[] bookModels = null;

            Action action = () => AuthorMapper.GetEntities(bookModels);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_GetEntities_WhenInputAreCorrect_ReturnsListOfAuthorEntities()
        {
            const string AuthorName = "Author";

            BookModel[] bookModels = new BookModel[1];
            bookModels[0] = new BookModel() { Author = AuthorName };

            IReadOnlyList<AuthorEntity> authorEntities = AuthorMapper.GetEntities(bookModels);

            foreach (AuthorEntity authorEntity in authorEntities)
            {
                Assert.IsTrue(authorEntity.Id != Guid.Empty);
                Assert.IsTrue(authorEntity.Name == AuthorName);
                Assert.IsNotNull(authorEntity.Books);
            }
        }
    }
}
