using Books.Classes;
using Books.DbContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Books
{
    public static class Startup
    {
        public static readonly IServiceProvider ServiceProvider;

        static Startup()
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .Build();

            IServiceCollection services = new ServiceCollection();

            services.AddTransient<LibraryContext>();
            services.AddSingleton<Filter>();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<App>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
