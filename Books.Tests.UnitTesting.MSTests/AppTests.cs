using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class AppTests
    {
        [TestMethod]
        public void Test_Run_WhenAllIsCorrect_ThrowsNoException()
        {
            const string expectedInputPath = "./Files/books.csv";

            App app = new App();
            string[] args = null;

            using (StringReader stringReader = new StringReader(expectedInputPath))
            {
                Console.SetIn(stringReader);

                app.Run(args);
            }
                
        }
    }
}
