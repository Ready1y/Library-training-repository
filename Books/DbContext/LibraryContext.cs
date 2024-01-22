using Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.DbContext
{
    public class LibraryContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=1234;Database=task5;Username=postgres;Password=12345");
        }
    }
}
