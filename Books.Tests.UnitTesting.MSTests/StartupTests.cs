using Books.Classes;
using Books.DbContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        public void Test_ServiceProvider_ReturnLibraryContextwhichIsNotNull()
        {
            LibraryContext libraryContext = Startup.ServiceProvider.GetService<LibraryContext>();

            Assert.IsNotNull(libraryContext);
        }

        [TestMethod]
        public void Test_ServiceProvider_ReturnFilterWhichIsNotNull()
        {
            Filter filter = Startup.ServiceProvider.GetService<Filter>();

            Assert.IsNotNull(filter);
        }

        [TestMethod]
        public void Test_ServiceProvider_ReturnIConfigurationWhichIsNotNull()
        {
            var configuration = Startup.ServiceProvider.GetService<IConfiguration>();

            Assert.IsNotNull(configuration);
        }

        [TestMethod]
        public void Test_ServiceProvider_ReturnAppWhichIsNotNull()
        {
            App app = Startup.ServiceProvider.GetService<App>();

            Assert.IsNotNull(app);
        }
    }
}