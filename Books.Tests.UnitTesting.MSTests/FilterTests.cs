using Books.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsAllParameters_ReturnFilterObject()
        {
            const string expectedTitle = "Title";
            const string expectedAuthor = "Author";
            const string expectedGenre = "Genre";
            const string expectedPublisher = "Publisher";
            const string moreThanPages = "100";
            const int expectedMoreThanPages = 100;
            const string lessThanPages = "200";
            const int expectedLessThanPages = 200;
            const string publishedBefore = "10.10.1900";
            DateTime expectedPublisheBefore = new DateTime(1900, 10, 10);
            const string publishedAfter = "10.10.1800";
            DateTime expectedPublisheAfter = new DateTime(1800, 10, 10);


            Filter filter = new Filter(expectedTitle, expectedGenre, expectedAuthor, expectedPublisher, moreThanPages, lessThanPages, publishedBefore, publishedAfter);

            Assert.AreEqual(expectedTitle, filter.Title);
            Assert.AreEqual(expectedGenre, filter.Genre);
            Assert.AreEqual(expectedAuthor, filter.Author);
            Assert.AreEqual(expectedPublisher, filter.Publisher);
            Assert.AreEqual(expectedMoreThanPages, filter.MoreThanPages);
            Assert.AreEqual(expectedLessThanPages, filter.LessThanPages);
            Assert.AreEqual(expectedPublisheBefore, filter.PublishedBefore);
            Assert.AreEqual(expectedPublisheAfter, filter.PublishedAfter);
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
    }
}