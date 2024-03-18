using Books.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class LibraryContextTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsNothing_ReturnsContextObject() 
        {
            LibraryContext libraryContext = new LibraryContext();

            Assert.IsNotNull(libraryContext);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputOptionIsCorrect_ReturnsContextObject()
        {
            DbContextOptions<LibraryContext> options = new DbContextOptions<LibraryContext>();

            LibraryContext context = new LibraryContext(options);

            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputOptionIsNull_ThrowsNullArgumentException()
        {
            DbContextOptions<LibraryContext> options = null;

            Action action = () => new LibraryContext(options);

            Assert.ThrowsException<ArgumentNullException>(action);
        }
    }
}
