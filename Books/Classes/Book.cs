using System;
using System.Collections.Generic;

namespace Books.Classes
{
    public class Book
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public int Pages { get; set; }
        public Guid GenreId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
        public ICollection<Genre> Genres { get; set; }

        public Book(Guid id, string title, int pages, Guid genreId, Guid authorId, Guid publisherId, DateTime releaseDate)
        {
            Id = id;
            Title = title;
            Pages = pages;
            GenreId = genreId;
            AuthorId = authorId;
            PublisherId = publisherId;
            ReleaseDate = releaseDate;
        }
    }
}
