using Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.DbContext
{
    using DbContext = Microsoft.EntityFrameworkCore.DbContext;

    public class LibraryContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books);

            modelBuilder.Entity<BookEntity>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books);

            modelBuilder.Entity<BookEntity>()
                .HasMany(b => b.Publishers)
                .WithMany(p => p.Books);
        }
    }
}
