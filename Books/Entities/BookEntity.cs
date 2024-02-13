using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<AuthorEntity> Authors { get; set; }
        public ICollection<PublisherEntity> Publishers { get; set; }
        public ICollection<GenreEntity> Genres { get; set; }
    }
}


