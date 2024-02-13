using Books.Classes;
using Books.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Books
{
    public static class Startup
    {
        public static readonly IServiceProvider ServiceProvider;
        public static readonly IConfiguration Configuration;

        static Startup()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build()
            ;

            IServiceCollection services = new ServiceCollection();

            string connectionString = @"Host=localhost;Port=1234;Database=task5;Username=postgres;Password=12345";

            services.AddDbContext<LibraryContext>(options => options.UseNpgsql(connectionString));
            services.AddSingleton<Filter>(Configuration.GetSection("FilterSettings").Get<Filter>());
            services.AddSingleton<App>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
