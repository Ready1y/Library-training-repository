using Books.Classes;
using Books.DbContext;
using Books.Interfaces;
using Books.Repositories;
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

        static Startup()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build()
            ;

            IServiceCollection services = new ServiceCollection();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<LibraryContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Scoped);
            services.AddSingleton<Filter>(configuration.GetSection("FilterSettings").Get<Filter>());
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<FileReader>();
            services.AddSingleton<App>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
