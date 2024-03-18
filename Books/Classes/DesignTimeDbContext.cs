using Microsoft.EntityFrameworkCore.Design;
using Books.DbContext;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Classes
{
    public class YourDbContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            LibraryContext libraryContext = Startup.ServiceProvider.GetRequiredService<LibraryContext>();

            return libraryContext;
        }
    }
}
