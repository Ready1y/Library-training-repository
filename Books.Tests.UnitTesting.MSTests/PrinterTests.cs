using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Books.Classes;
using System.IO;
using Books.Models;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class PrinterTests
    {
        [TestMethod]
        public void Test_PrintResultInConsole_WhenInputListIsNull_ThrowsArgumentNullException()
        {
            List<BookModel> books = null;

            Action action = () => Printer.PrintResultInConsole(books);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_PrintResultInConsole_ValidList_PrintsCountAndTitles()
        {
            string[] expectedLines = new string[3]
            {
                "Count of books with these settings are 2",
                "Title1",
                "Title2"
            };

            List<BookModel> books = new List<BookModel>
            {
                { new BookModel("Title1", 100, "Genre1", "Author1", "Publisher1", DateTime.MinValue) },
                { new BookModel("Title2", 200, "Genre2", "Author2", "Publisher2", DateTime.MinValue) }
            };

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Printer.PrintResultInConsole(books);

                string[] actualLines = stringWriter.ToString().Split(Environment.NewLine);

                for (int i = 0; i < expectedLines.Length; i++)
                {
                    Assert.AreEqual(expectedLines[i], actualLines[i]);
                }
            }
        }

        [TestMethod]
        public void Test_PrintResultsToFile_WhenInputListIsNull_ThrowsArgumentNullException()
        {
            string directoryPath = string.Empty;
            List<BookModel> books = null;

            Action action = () => Printer.PrintResultsToFile(directoryPath, books);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_PrintResultsToFile_WhenInputFileDirectoryIsNull_ThrowsArgumentException()
        {
            string directoryPath = null;
            List<BookModel> books = new List<BookModel>
            {
                { new BookModel() }
            };

            Action action = () => Printer.PrintResultsToFile(directoryPath, books);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_PrintResultsToFile_WhenInputFileDirectoryContainsInvalidPathChars_ThrowsArgumentException()
        {
            string directoryPath = ".|Files|";
            List<BookModel> books = new List<BookModel>
            {
                { new BookModel() }
            };

            Action action = () => Printer.PrintResultsToFile(directoryPath, books);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_PrintResultsToFile_WhenInputFileDirectoryIsWrong_ThrowsArgumentException()
        {
            string directoryPath = "./Filessssss/";
            List<BookModel> books = new List<BookModel>
            {
                { new BookModel() }
            };

            Action action = () => Printer.PrintResultsToFile(directoryPath, books);

            Assert.ThrowsException<DirectoryNotFoundException>(action);
        }

        [TestMethod]
        public void Test_PrintResultsToFile_ValidInput_CreatesFileWithCorrectContent()
        {
            string directoryOfFile = "./Files/";

            DateTime time = DateTime.Now;

            string fileName = $"{time:yyyyMMdd_HHmmss}.txt";

            string filePath = System.IO.Path.Combine(directoryOfFile, fileName);

            string[] expectedLines = new string[2]
            {
                "Title1,100,Genre1,1/1/0001,Author1,Publisher1",
                "Title2,200,Genre2,1/1/0001,Author2,Publisher2"
            };

            List<BookModel> books = new List<BookModel>
            {
                { new BookModel("Title1", 100, "Genre1", "Author1", "Publisher1", DateTime.MinValue) },
                { new BookModel("Title2", 200, "Genre2", "Author2", "Publisher2", DateTime.MinValue) }
            };

            Printer.PrintResultsToFile(directoryOfFile, books);

            string[] actualLines = File.ReadAllLines(filePath.ToString());

            for (int i = 0; i < expectedLines.Length; i++)
            {
                Assert.AreEqual(expectedLines[i], actualLines[i]);
            }
        }
    }
}