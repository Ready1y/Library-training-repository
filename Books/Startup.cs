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

        private static DbContextOptionsBuilder UseSQLFactory(this DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            const string SqlProviderKey = "SQLProvider";
            const string NpgSQLValue = "NpgSQL";
            const string MsSQLValue = "MsSQL";

            const string NpgSQLConnectionStringKey = "NpgSQLConnection";
            const string MsSQLConnectionStringKey = "MsSQLConnection";

            string sqlProvider = configuration.GetSection(SqlProviderKey).Value;

            if (string.IsNullOrWhiteSpace(sqlProvider))
            {
                throw new MissingFieldException("There is a missing value for the key 'SQLProvider'. Probably an invalid key.");
            }

            switch (sqlProvider)
            {
                case NpgSQLValue:
                    string NpgSqlConnectionString = configuration.GetConnectionString(NpgSQLConnectionStringKey);

                    UseNpgSQL(optionsBuilder, NpgSqlConnectionString);
                    break;

                case MsSQLValue:
                    string MsSqlConnectionString = configuration.GetConnectionString(MsSQLConnectionStringKey);

                    UseMsSQL(optionsBuilder, MsSqlConnectionString);
                    break;

                default:
                    throw new NotSupportedException(string.Format(
                        "Provider '{0}' is not supported.{1}{1}Available providers:{1}{2}",
                        sqlProvider,
                        Environment.NewLine,
                        string.Join(
                            Environment.NewLine,
                            new string[]
                            {
                                NpgSQLValue,
                                MsSQLValue
                            }
                        )
                    ));
            }

            return optionsBuilder;
        }

        private static void UseNpgSQL(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        private static void UseMsSQL(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
