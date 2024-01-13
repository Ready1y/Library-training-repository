using Books.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class PathValidatorTests
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("          ")]
        public void Test_ValidationForFile_WhenInputFilePathIsNull_ThrowsArgumentNullException(string wrongPath)
        {
            Action action = () => PathValidator.ValidationForFile(wrongPath);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_ValidationForFile_WhenInputFilePathContainsInvalidPathChars_ThrowsArgumentException()
        {
            const string WrongPath = ".|Files|File.txt";

            Action action = () => PathValidator.ValidationForFile(WrongPath);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_ValidationForFile_WhenInputFileDirectoryIsWrong_ThrowsDirectoryNotFoundException()
        {
            const string WrongPath = "./Filsssss/File.txt";

            Action action = () => PathValidator.ValidationForFile(WrongPath);

            Assert.ThrowsException<DirectoryNotFoundException>(action);
        }

        [TestMethod]
        public void Test_ValidationForFile_WhenInputFileNameIsWrong_ThrowsFileNotFoundException()
        {
            const string WrongPath = "./Files/File123.txt";

            Action action = () => PathValidator.ValidationForFile(WrongPath);

            Assert.ThrowsException<FileNotFoundException>(action);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("          ")]
        public void Test_ValidationForDirectory_WhenInputFilePathIsNull_ThrowsArgumentNullException(string wrongPath)
        {
            Action action = () => PathValidator.ValidationForDirectory(wrongPath);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_ValidationForDirectory_WhenInputFilePathContainsInvalidPathChars_ThrowsArgumentException()
        {
            const string WrongPath = ".|Files|File.txt";

            Action action = () => PathValidator.ValidationForDirectory(WrongPath);

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void Test_ValidationForDirectory_WhenInputFileDirectoryIsWrong_ThrowsDirectoryNotFoundException()
        {
            const string WrongPath = "./Filsssss/File.txt";

            Action action = () => PathValidator.ValidationForDirectory(WrongPath);

            Assert.ThrowsException<DirectoryNotFoundException>(action);
        }
    }
}