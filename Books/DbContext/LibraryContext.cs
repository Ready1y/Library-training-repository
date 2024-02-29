using Books.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Books.DbContext
{
    using DbContext = Microsoft.EntityFrameworkCore.DbContext;

    public class LibraryContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<PublisherEntity> Publishers { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) 
            : base(options)
        {
            if(options == null)
            {
                throw new ArgumentNullException(nameof(options), "Options are null");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<AuthorEntity>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<GenreEntity>()
                .HasKey(g => g.Id);

            modelBuilder.Entity<PublisherEntity>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<BookEntity>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
            ;

            modelBuilder.Entity<BookEntity>()
                .HasMany(b => b.Genres)
                .WithMany(g => g.Books)
            ;

            modelBuilder.Entity<BookEntity>()
                .HasMany(b => b.Publishers)
                .WithMany(p => p.Books)
            ;

            modelBuilder.Entity<AuthorEntity>()
                .HasMany(b => b.Books)
                .WithMany(a => a.Authors)
            ;

            modelBuilder.Entity<GenreEntity>()
                .HasMany(b => b.Books)
                .WithMany(a => a.Genres)
            ;

            modelBuilder.Entity<PublisherEntity>()
                .HasMany(b => b.Books)
                .WithMany(a => a.Publishers)
            ;
        }
    }
}
