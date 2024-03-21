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

            services.AddDbContext<LibraryContext>(options => options.UseSQLFactory(configuration), ServiceLifetime.Scoped);
            services.AddSingleton<Filter>(configuration.GetSection("FilterSettings").Get<Filter>());
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IFileReader, FileReader>();
            services.AddSingleton<App>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static DbContextOptionsBuilder UseSQLFactory(this DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            string sqlProvider = configuration.GetSection("SQLProviders").Value;

            switch (sqlProvider)
            {
                case "NpgSQL":
                    UseNpgSQL(optionsBuilder, configuration.GetConnectionString("DefaultConnection"));
                    break;

                case "MsSQL":
                    UseMsSQL(optionsBuilder, configuration.GetConnectionString("DefaultConnection"));
                    break;

                default:
                    Console.WriteLine(sqlProvider);
                    throw new ArgumentException("SQL provider is incorreect", nameof(sqlProvider));
            }

            return optionsBuilder;
        }

        private static void UseNpgSQL(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            if(optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder), "Options builder is null");
            }

            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string is null");
            }

            optionsBuilder.UseNpgsql(connectionString);
        }

        private static void UseMsSQL(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder), "Options builder is null");
            }

            if (connectionString == null)
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string is null");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
