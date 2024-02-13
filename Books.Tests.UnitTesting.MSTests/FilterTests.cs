using Books.Classes;
using Books.DbContext;
using Books.Models;
using Books.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputConfigurationIsNull_ThrowsArgumentNullException()
        {
            Action action = () => new Filter(null);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputIsValidConfiguration_ReturnFilterObject()
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .Build();

            Filter filter = new Filter(configuration);

            Assert.AreEqual("", filter.Title);
            Assert.AreEqual("", filter.Genre);
            Assert.AreEqual("", filter.Author);
            Assert.AreEqual("", filter.Publisher);
            Assert.AreEqual(0, filter.MoreThanPages);
            Assert.AreEqual(0, filter.LessThanPages);
            Assert.AreEqual(DateTime.MinValue, filter.PublishedBefore);
            Assert.AreEqual(DateTime.MinValue, filter.PublishedAfter);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputIsNothing_ReturnFilterObject()
        {
            Filter filter = new Filter();

            Assert.AreEqual(null, filter.Title);
            Assert.AreEqual(null, filter.Genre);
            Assert.AreEqual(null, filter.Author);
            Assert.AreEqual(null, filter.Publisher);
            Assert.AreEqual(null, filter.MoreThanPages);
            Assert.AreEqual(null, filter.LessThanPages);
            Assert.AreEqual(null, filter.PublishedBefore);
            Assert.AreEqual(null, filter.PublishedAfter);
        }

        [TestMethod]
        public void Test_GetTitle_ReturnsTitle()
        {
            Filter filter = new Filter();

            string actualTitle = filter.Title;

            Assert.AreEqual(filter.Title, actualTitle);
        }

        [TestMethod]
        public void Test_SetTitle_SetValueToTitle()
        {
            string expectedTitle = "Title";

            Filter filter = new Filter();

            filter.Title = expectedTitle;

            Assert.AreEqual(expectedTitle, filter.Title);
        }

        [TestMethod]
        public void Test_GetGenre_ReturnsGenre()
        {
            Filter filter = new Filter();

            string actualGenre = filter.Genre;

            Assert.AreEqual(filter.Genre, actualGenre);
        }

        [TestMethod]
        public void Test_SetGenre_SetValueToGenre()
        {
            string expectedGenre = "Genre";

            Filter filter = new Filter();

            filter.Genre = expectedGenre;

            Assert.AreEqual(expectedGenre, filter.Genre);
        }

        [TestMethod]
        public void Test_GetAuthor_ReturnsAuthor()
        {
            Filter filter = new Filter();

            string actualAuthor = filter.Author;

            Assert.AreEqual(filter.Author, actualAuthor);
        }

        [TestMethod]
        public void Test_SetAuthor_SetValueToAuthor()
        {
            string expectedAuthor = "Author";

            Filter filter = new Filter();

            filter.Author = expectedAuthor;

            Assert.AreEqual(expectedAuthor, filter.Author);
        }

        [TestMethod]
        public void Test_GetPublisher_ReturnsPublisher()
        {
            Filter filter = new Filter();

            string actualPublisher = filter.Publisher;

            Assert.AreEqual(filter.Publisher, actualPublisher);
        }

        [TestMethod]
        public void Test_SetPublisher_SetValueToPublisher()
        {
            string expectedPublisher = "Publisher";

            Filter filter = new Filter();

            filter.Publisher = expectedPublisher;

            Assert.AreEqual(expectedPublisher, filter.Publisher);
        }

        [TestMethod]
        public void Test_GetMoreThanPages_ReturnsMoreThanPages()
        {
            Filter filter = new Filter();

            int? actualMoreThanPages = filter.MoreThanPages;

            Assert.AreEqual(filter.MoreThanPages, actualMoreThanPages);
        }

        [TestMethod]
        public void Test_SetMoreThanPages_SetValueToMoreThanPages()
        {
            int? expectedMoreThanPages = 100;

            Filter filter = new Filter();

            filter.MoreThanPages = expectedMoreThanPages;

            Assert.AreEqual(expectedMoreThanPages, filter.MoreThanPages);
        }

        [TestMethod]
        public void Test_GetLessThanPages_ReturnsLessThanPages()
        {
            Filter filter = new Filter();

            int? actualLessThanPages = filter.LessThanPages;

            Assert.AreEqual(filter.LessThanPages, actualLessThanPages);
        }

        [TestMethod]
        public void Test_SetLessThanPages_SetValueToLessThanPages()
        {
            int? expectedLessThanPages = 100;

            Filter filter = new Filter();

            filter.LessThanPages = expectedLessThanPages;

            Assert.AreEqual(expectedLessThanPages, filter.LessThanPages);
        }

        [TestMethod]
        public void Test_GetPublishedBefore_ReturnsPublishedBefore()
        {
            Filter filter = new Filter();

            DateTime? actualPublishedBefore = filter.PublishedBefore;

            Assert.AreEqual(filter.PublishedBefore, actualPublishedBefore);
        }

        [TestMethod]
        public void Test_SetPublishedBefore_SetValueToPublishedBefore()
        {
            DateTime? expectedPublishedBefore = DateTime.MinValue;

            Filter filter = new Filter();

            filter.PublishedBefore = expectedPublishedBefore;

            Assert.AreEqual(expectedPublishedBefore, filter.PublishedBefore);
        }

        [TestMethod]
        public void Test_GetPublishedAfter_ReturnsPublishedAfter()
        {
            Filter filter = new Filter();

            DateTime? actualPublishedAfter = filter.PublishedAfter;

            Assert.AreEqual(filter.PublishedAfter, actualPublishedAfter);
        }

        [TestMethod]
        public void Test_SetPublishedAfter_SetValueToPublishedAfter()
        {
            DateTime? expectedPublishedAfter = DateTime.MinValue;

            Filter filter = new Filter();

            filter.PublishedAfter = expectedPublishedAfter;

            Assert.AreEqual(expectedPublishedAfter, filter.PublishedAfter);
        }

        [TestMethod]
        public void Test_FindBooksInContext_WhenInputContextIsNull_ThrowsArgumentNullException()
        {
            LibraryContext context = null;

            Filter filter = new Filter();

            Action action = () => filter.FindBooksInContext(context);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        [DataRow(null, null, null, null, null, null, null, null, 5)]
        [DataRow("Title1", null, null, null, null, null, null, null, 1)]
        [DataRow(null, "Genre2", null, null, null, null, null, null, 2)]
        [DataRow(null, null, "Author2", null, null, null, null, null, 1)]
        [DataRow(null, null, null, "Publisher5", null, null, null, null, 1)]
        [DataRow(null, null, null, null, 400, null, null, null, 3)]
        [DataRow(null, null, null, null, null, 500, null, null, 0)]
        [DataRow(null, null, null, null, null, null, "1900-10-10", null, 1)]
        [DataRow(null, null, null, null, null, null, null, "1700-10-10", 2)]
        [DataRow(null, null, null, null, 200, null, null, "1700-10-10", 1)]
        public void Test_FindBooksInContext_WhenInputIsCorrect_ReturnsDictionaryWithResults(string filterParameterTitle, string filterParameterGenre, string filterParameterAuthor, string filterParameterPublisher, int? filterParameterLessThanPages, int? filterParameterMoreThanPages, string filterParameterPublishedAfterString, string filterParameterPublishedBeforeString, int expectedResultsOfFiltering)
        {
            DateTime? filterParameterPublishedAfter;
            if (filterParameterPublishedAfterString == null)
            {
                filterParameterPublishedAfter = null;
            }
            else
            {
                filterParameterPublishedAfter = DateTime.Parse(filterParameterPublishedAfterString);
            }

            DateTime? filterParameterPublishedBefore;
            if (filterParameterPublishedBeforeString == null)
            {
                filterParameterPublishedBefore = null;
            }
            else
            {
                filterParameterPublishedBefore = DateTime.Parse(filterParameterPublishedBeforeString);
            }

            using (LibraryContext context = new LibraryContext())
            {
                context.ChangeTracker.Clear();

                BookModel[] modelsOfBooks = new BookModel[5];
                modelsOfBooks[0] = new BookModel("Title1", 100, "Genre1", "Author1", "Publisher1", new DateTime(1563, 6, 24));
                modelsOfBooks[1] = new BookModel("Title2", 200, "Genre2", "Author2", "Publisher2", new DateTime(1663, 7, 25));
                modelsOfBooks[2] = new BookModel("Title3", 300, "Genre2", "Author3", "Publisher3", new DateTime(1763, 11, 22));
                modelsOfBooks[3] = new BookModel("Title4", 400, "Genre3", "Author3", "Publisher4", new DateTime(1863, 12, 21));
                modelsOfBooks[4] = new BookModel("Title5", 500, "Genre4", "Author4", "Publisher5", new DateTime(1963, 1, 24));

                LibraryRepository libraryRepository = new LibraryRepository(context);

                for (int i = 0; i < modelsOfBooks.Length; i++)
                {
                    libraryRepository.AddBook(modelsOfBooks[i]);
                }

                Filter filter = new Filter();

                filter.Title = filterParameterTitle;
                filter.Genre = filterParameterGenre;
                filter.Author = filterParameterAuthor;
                filter.Publisher = filterParameterPublisher;
                filter.LessThanPages = filterParameterLessThanPages;
                filter.MoreThanPages = filterParameterMoreThanPages;
                filter.PublishedAfter = filterParameterPublishedAfter;
                filter.PublishedBefore = filterParameterPublishedBefore;

                Dictionary<uint, BookModel> actualResultsOfFiltering = filter.FindBooksInContext(context);

                Assert.AreEqual(expectedResultsOfFiltering, actualResultsOfFiltering.Count);
            }
        }
    }
}