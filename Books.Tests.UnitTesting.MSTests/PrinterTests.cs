using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Books.Classes;
using System.IO;
using Books.Models;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class PrinterTests
    {
        [TestMethod]
        public void Test_PrintResultInConsole_WhenInputDictionaryIsNull_ThrowsArgumentNullException()
        {
            Dictionary<uint, BookModel> dictionaryOfBooks = null;

            Action action = () => Printer.PrintResultInConsole(dictionaryOfBooks);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_PrintResultInConsole_ValidDictionary_PrintsCountAndTitles()
        {
            string[] expectedLines = new string[3]
            {
                "Count of books with these settings are 2",
                "Title1",
                "Title2"
            };

            Dictionary<uint, BookModel> dictionaryOfBooks = new Dictionary<uint, BookModel>
            {
                { 1, new BookModel("Title1", 100, "Genre1", "Author1", "Publisher1", DateTime.MinValue) },
                { 2, new BookModel("Title2", 200, "Genre2", "Author2", "Publisher2", DateTime.MinValue) }
            };

            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                Printer.PrintResultInConsole(dictionaryOfBooks);

                string[] actualLines = stringWriter.ToString().Split(Environment.NewLine);

                for(int i = 0; i < expectedLines.Length; i++)
                {
                    Assert.AreEqual(expectedLines[i], actualLines[i]);
                }
            }
        }

        [TestMethod]
        public void Test_PrintResultsToFile_WhenInputDictionaryIsNull_ThrowsArgumentNullException()
        {
            string directoryPath = string.Empty;
            Dictionary<uint, BookModel> dictionaryOfBooks = null;

            Action action = () => Printer.PrintResultsToFile(directoryPath, dictionaryOfBooks);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_PrintResultsToFile_WhenInputPathIsNull_ThrowsArgumentException()
        {
            string directoryPath = null;
            Dictionary<uint, BookModel> dictionaryOfBooks = new Dictionary<uint, BookModel>
            {
                { 1, new BookModel() }
            };

            Action action = () => Printer.PrintResultsToFile(directoryPath, dictionaryOfBooks);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_PrintResultsToFile_WhenInputPathContainsInvalidPathChars_ThrowsArgumentException()
        {
            string directoryPath = ".|Files|";
            Dictionary<uint, BookModel> dictionaryOfBooks = new Dictionary<uint, BookModel>
            {
                { 1, new BookModel() }
            };

            Action action = () => Printer.PrintResultsToFile(directoryPath, dictionaryOfBooks);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_PrintResultsToFile_WhenInputFileDirectoryIsWrong_ThrowsArgumentException()
        {
            string directoryPath = "./Filessssss/";
            Dictionary<uint, BookModel> dictionaryOfBooks = new Dictionary<uint, BookModel>
            {
                { 1, new BookModel() }
            };

            Action action = () => Printer.PrintResultsToFile(directoryPath, dictionaryOfBooks);

            Assert.ThrowsException<DirectoryNotFoundException>(action);
        }

        [TestMethod]
        public void Test_PrintResultsToFile_ValidInput_CreatesFileWithCorrectContent()
        {
            string directoryOfFile = "./Files/";

            StringBuilder filePath = new StringBuilder(directoryOfFile);

            DateTime time = DateTime.Now;
            string fileName = $"{time:yyyyMMdd_HHmmss}.txt";
            filePath.Append(fileName);

            string[] expectedLines = new string[2]
            {
                "Title1,100,Genre1,01.01.0001,Author1,Publisher1",
                "Title2,200,Genre2,01.01.0001,Author2,Publisher2"
            };

            Dictionary<uint, BookModel> dictionaryOfBooks = new Dictionary<uint, BookModel>
            {
                { 1, new BookModel("Title1", 100, "Genre1", "Author1", "Publisher1", DateTime.MinValue) },
                { 2, new BookModel("Title2", 200, "Genre2", "Author2", "Publisher2", DateTime.MinValue) }
            };

            Printer.PrintResultsToFile(directoryOfFile, dictionaryOfBooks);

            string[] actualLines = File.ReadAllLines(filePath.ToString());

            for(int i = 0; i < expectedLines.Length; i++)
            {
                Assert.AreEqual(expectedLines[i], actualLines[i]);
            }
        }
    }
}