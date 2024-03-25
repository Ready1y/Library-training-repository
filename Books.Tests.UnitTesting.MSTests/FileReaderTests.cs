using Books.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using Books.Models;
using System.Collections.Generic;
using System.Linq;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void Test_Constructor_WhenFilterIsNull_ThrowsArgumentNullException()
        {
            Filter filter = null;

            Action action = () => new FileReader(filter);
            
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_Constructor_WhenInputIsCorrect_CreateFilereaderObject()
        {
            Filter filter = new Filter();

            FileReader fileReader = new FileReader(filter);

            Assert.IsNotNull(fileReader);
        }

        [TestMethod]
        public void Test_Read_WhenInputFilePathIsCorrect_ReturnCorrectLinesFromFile()
        {
            const string InputPath = "./Files/books.csv";

            BookModel book1 = new BookModel("To Kill a Mockingbird", 336, "Fiction", "Harper Lee", "HarperCollins", new DateTime(1960, 07, 11));
            BookModel book2 = new BookModel("1984", 328, "Science Fiction", "George Orwell", "Signet Classics", new DateTime(1949, 06, 08));
            BookModel book3 = new BookModel("The Great Gatsby", 180, "Classics", "F. Scott Fitzgerald", "Scribner", new DateTime(1925, 04, 10));
            BookModel book4 = new BookModel("Pride and Prejudice", 432, "Romance", "Jane Austen", "Penguin Classics", new DateTime(1813, 01, 28));

            List<BookModel> expectedBooks = new List<BookModel>{ book1, book2, book3, book4 };

            Filter filter = new Filter();
            FileReader fileReader = new FileReader(filter);

            IReadOnlyList<BookModel> actualBooks = fileReader.Read(InputPath);

            BookModel[] result = expectedBooks.Except(actualBooks).ToArray();

            Assert.AreEqual(result.Length, 0);
        }

        [TestMethod]
        public void Test_Read_WhenInputFilePathIsNull_ThrowsArgumentException()
        {
            const string WrongPath = null;

            Filter filter = new Filter();
            FileReader fileReader = new FileReader(filter);

            Action action = () => fileReader.Read(WrongPath);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_Read_WhenInputFilePathContainsInvalidPathChars_ThrowsArgumentException()
        {
            const string WrongPath = ".|Files|InputFile.txt";

            Filter filter = new Filter();
            FileReader fileReader = new FileReader(filter);

            Action action = () => fileReader.Read(WrongPath);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_Read_WhenInputFileDirectoryIsWrong_ThrowsDirectoryNotFoundException()
        {
            const string WrongPath = "./Filsssss/InputFile.txt";

            Filter filter = new Filter();
            FileReader fileReader = new FileReader(filter);

            Action action = () => fileReader.Read(WrongPath);

            Assert.ThrowsException<DirectoryNotFoundException>(action);
        }

        [TestMethod]
        public void Test_Read_WhenInputFileNameIsWrong_ThrowsFileNotFoundException()
        {
            const string WrongPath = "./Files/File123.txt";

            Filter filter = new Filter();
            FileReader fileReader = new FileReader(filter);

            Action action = () => fileReader.Read(WrongPath);

            Assert.ThrowsException<FileNotFoundException>(action);
        }
    }
}
