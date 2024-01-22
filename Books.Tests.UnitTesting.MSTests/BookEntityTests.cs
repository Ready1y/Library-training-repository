using Books.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class BookEntityTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsSevenParameters_ReturnsAuthorObject()
        {
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            Assert.AreEqual(expectedIds, book.Id);
            Assert.AreEqual(expectedTitle, book.Title);
            Assert.AreEqual(expectedPages, book.Pages);
            Assert.AreEqual(expectedIds, book.GenreId);
            Assert.AreEqual(expectedIds, book.AuthorId);
            Assert.AreEqual(expectedIds, book.PublisherId);
            Assert.AreEqual(expectedReleasedDate, book.ReleaseDate);
        }

        [TestMethod]
        public void Test_GetId_ReturnsId()
        {
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            Guid actualId = book.Id;

            Assert.AreEqual(expectedIds, actualId);
        }

        [TestMethod]
        public void Test_SetId_SetValueToId()
        {
            Guid startId = Guid.Empty;
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(startId, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            book.Id = expectedIds;

            Assert.AreEqual(expectedIds, book.Id);
        }

        [TestMethod]
        public void Test_GetTitle_ReturnsTitle()
        {
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            string actualTitle = book.Title;

            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [TestMethod]
        public void Test_SetTitle_SetValueToTitle()
        {
            const string startTitle = "name";
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, startTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            book.Title = expectedTitle;

            Assert.AreEqual(expectedTitle, book.Title);
        }

        [TestMethod]
        public void Test_GetPages_ReturnsPages()
        {
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            int actualPages = book.Pages;

            Assert.AreEqual(expectedPages, actualPages);
        }

        [TestMethod]
        public void Test_SetPages_SetValueToPages()
        {
            const int startPages = 1;
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, startPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            book.Pages = expectedPages;

            Assert.AreEqual(expectedPages, book.Pages);
        }

        [TestMethod]
        public void Test_GetGenreId_ReturnsGenreId()
        {
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            Guid actualGenreId = book.GenreId;

            Assert.AreEqual(expectedIds, actualGenreId);
        }

        [TestMethod]
        public void Test_SetGenreId_SetValueToGenreId()
        {
            Guid startId = Guid.Empty;
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, startId, expectedIds, expectedIds, expectedReleasedDate);

            book.GenreId = expectedIds;

            Assert.AreEqual(expectedIds, book.GenreId);
        }

        [TestMethod]
        public void Test_GetAuthorId_ReturnsAuthorId()
        {
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            Guid actualAuthorId = book.AuthorId;

            Assert.AreEqual(expectedIds, actualAuthorId);
        }

        [TestMethod]
        public void Test_SetAuthorId_SetValueToAuthorId()
        {
            Guid startId = Guid.Empty;
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, startId, expectedIds, expectedReleasedDate);

            book.AuthorId = expectedIds;

            Assert.AreEqual(expectedIds, book.AuthorId);
        }

        [TestMethod]
        public void Test_GetPublisherId_ReturnsPublisherId()
        {
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            Guid actualPublisherId = book.PublisherId;

            Assert.AreEqual(expectedIds, actualPublisherId);
        }

        [TestMethod]
        public void Test_SetPublisherId_SetValueToPublisherId()
        {
            Guid startId = Guid.Empty;
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, startId, expectedReleasedDate);

            book.PublisherId = expectedIds;

            Assert.AreEqual(expectedIds, book.PublisherId);
        }

        [TestMethod]
        public void Test_GetReleaseDate_ReturnsReleaseDate()
        {
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, expectedReleasedDate);

            DateTime actualPublisherId = book.ReleaseDate;

            Assert.AreEqual(expectedReleasedDate, actualPublisherId);
        }

        [TestMethod]
        public void Test_SetReleaseDate_SetValueToReleaseDate()
        {
            DateTime startReleaseDate = DateTime.MaxValue;
            const string expectedTitle = "Book";
            Guid expectedIds = Guid.NewGuid();
            const int expectedPages = 2;
            DateTime expectedReleasedDate = DateTime.MinValue;

            BookEntity book = new BookEntity(expectedIds, expectedTitle, expectedPages, expectedIds, expectedIds, expectedIds, startReleaseDate);

            book.ReleaseDate = expectedReleasedDate;

            Assert.AreEqual(expectedReleasedDate, book.ReleaseDate);
        }
    }
}