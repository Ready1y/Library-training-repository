using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;

namespace Books.Tests.UnitTesting.MSTests
{
    using Path = Classes.Path;

    [TestClass]
    public class PathTests
    {
        [TestMethod]
        public void Test_GetFromArgs_InputNameOfSearchPathIsNull_ReturnsEmptyString()
        {
            string[] args = new string[1];
            string nameOfSearchPath = null;

            string actualFilePath = Path.GetFromArgs(args, nameOfSearchPath);

            Assert.AreEqual(string.Empty, actualFilePath);
        }

        [TestMethod]
        public void Test_GetFromArgs_InputArgsIsNull_ReturnsEmptyString()
        {
            string[] args = null;

            string actualFilePath = Path.GetFromArgs(args, string.Empty);

            Assert.AreEqual(string.Empty, actualFilePath);
        }

        [TestMethod]
        [DataRow(new string[] { })]
        [DataRow(new string[] { "asdasdasd", " ", "expectedInputPath", "/dada/daddas/dad" })]
        public void Test_GetFromArgs_InputArgsWithNoCorrectPath_ReturnsEmptyString(string[] args)
        {
            string actualFilePath = Path.GetFromArgs(args, string.Empty);

            Assert.AreEqual(string.Empty, actualFilePath);
        }

        [TestMethod]
        public void Test_GetFromArgs_InputIsCorrect_ReturnsFilePath()
        {
            const string nameOfPath = "Input path = \"";
            const string expectedInputPath = "./Files/books.csv";
            const string inputPath = "Input path = \"./Files/books.csv\"";

            string[] args = new string[] { "asdasdasd", " ", inputPath };

            string actualFilePath = Path.GetFromArgs(args, nameOfPath);

            Assert.AreEqual(expectedInputPath, actualFilePath);
        }

        [TestMethod]
        public void Test_GetFromUserInput_InputIsCorrect_ReturnsFilePath()
        {
            const string expectedInputPath = "./Files/books.csv";

            using (StringReader stringReader = new StringReader($"{expectedInputPath}"))
            {
                Console.SetIn(stringReader);

                string actualFilePath = Path.GetFromUserInput();

                Assert.AreEqual(expectedInputPath, actualFilePath);
            }
        }
    }
}
