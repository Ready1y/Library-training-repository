using Books.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class BookCsvMapperTests
    {
        [TestMethod]
        public void Test_Constructor_WhenInputIsNothing_ObjectIsNotNull()
        {
            BookCsvMapper bookCsvMapper = new BookCsvMapper();

            Assert.IsNotNull(bookCsvMapper);
        }
    }
}
