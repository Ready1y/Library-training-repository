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

        public override bool Equals(object obj)
        {
            return obj is BookEntity entity &&
                   Id.Equals(entity.Id) &&
                   Title == entity.Title &&
                   Pages == entity.Pages &&
                   ReleaseDate == entity.ReleaseDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Pages, ReleaseDate);
        }
    }
}


