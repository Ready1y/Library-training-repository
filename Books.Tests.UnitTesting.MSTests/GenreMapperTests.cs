using Books.Entities;
using Books.Mappers;
using Books.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class GenreMapperTests
    {
        [TestMethod]
        public void Test_GetEntities_WhenInputBookModelsAreNull_ThrowsArgumentNullException()
        {
            BookModel[] bookModels = null;

            Action action = () => GenreMapper.GetEntities(bookModels);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_GetEntities_WhenInputAreCorrect_ReturnsListOfGenreEntities()
        {
            const string GenreName = "Genre";

            BookModel[] bookModels = new BookModel[1];
            bookModels[0] = new BookModel() { Genre = GenreName };

            IReadOnlyList<GenreEntity> genreEntities = GenreMapper.GetEntities(bookModels);

            foreach (GenreEntity genreEntity in genreEntities)
            {
                Assert.IsTrue(genreEntity.Id != Guid.Empty);
                Assert.IsTrue(genreEntity.Name == GenreName);
                Assert.IsNotNull(genreEntity.Books);
            }
        }
    }
}
