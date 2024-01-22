using Books.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using Books.Models;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void Test_Read_WhenInputFileIsEmpty_ReturnNull()
        {
            const string InputPath = "./Files/EmptyFile.txt";

            BookModel[] info = FileReader.Read(InputPath);

            Assert.IsNull(info);
        }

        [TestMethod]
        public void Test_Read_WhenInputFilePathIsCorrect_ReturnCorrectLinesFromFile()
        {
            const string InputPath = "./Files/books.csv";

            BookModel book1 = new BookModel("To Kill a Mockingbird", 336, "Fiction", "Harper Lee", "HarperCollins", new DateTime(1960, 07, 11));
            BookModel book2 = new BookModel("1984", 328, "Science Fiction", "George Orwell", "Signet Classics", new DateTime(1949, 06, 08));
            BookModel book3 = new BookModel("The Great Gatsby", 180, "Classics", "F. Scott Fitzgerald", "Scribner", new DateTime(1925, 04, 10));
            BookModel book4 = new BookModel("Pride and Prejudice", 432, "Romance", "Jane Austen", "Penguin Classics", new DateTime(1813, 01, 28));

            BookModel[] expectedBooks = { book1, book2, book3, book4 };

            BookModel[] actualBooks = FileReader.Read(InputPath);

            for (int i = 0; i < actualBooks.Length; i++)
            {
                Assert.AreEqual(expectedBooks[i].Title, actualBooks[i].Title);
                Assert.AreEqual(expectedBooks[i].Pages, actualBooks[i].Pages);
                Assert.AreEqual(expectedBooks[i].Genre, actualBooks[i].Genre);
                Assert.AreEqual(expectedBooks[i].Author, actualBooks[i].Author);
                Assert.AreEqual(expectedBooks[i].Publisher, actualBooks[i].Publisher);
                Assert.AreEqual(expectedBooks[i].ReleaseDate, actualBooks[i].ReleaseDate);
            }
        }

        [TestMethod]
        public void Test_Read_WhenInputFilePathIsNull_ThrowsArgumentException()
        {
            const string WrongPath = null;

            Action action = () => FileReader.Read(WrongPath);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_Read_WhenInputFilePathContainsInvalidPathChars_ThrowsArgumentException()
        {
            const string WrongPath = ".|Files|InputFile.txt";

            Action action = () => FileReader.Read(WrongPath);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_Read_WhenInputFileDirectoryIsWrong_ThrowsDirectoryNotFoundException()
        {
            const string WrongPath = "./Filsssss/InputFile.txt";

            Action action = () => FileReader.Read(WrongPath);

            Assert.ThrowsException<DirectoryNotFoundException>(action);
        }

        [TestMethod]
        public void Test_Read_WhenInputFileNameIsWrong_ThrowsFileNotFoundException()
        {
            const string WrongPath = "./Files/File123.txt";

            Action action = () => FileReader.Read(WrongPath);

            Assert.ThrowsException<FileNotFoundException>(action);
        }
    }
}
