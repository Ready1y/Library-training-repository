using Books.Classes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class StartupTests
    {

        [TestMethod]
        public void ConfigureServices_ShouldAddFilterToDIContainer()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder().Build(); 

            var startup = new Startup();

            startup.ConfigureServices(services, configuration);

            var serviceProvider = services.BuildServiceProvider();
            var filter = serviceProvider.GetService<Filter>();

            Assert.IsNotNull(filter);
        }
    }
}