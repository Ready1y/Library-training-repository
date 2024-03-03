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

        public bool Equals(BookEntity bookEntity)
        {
            if (bookEntity == null)
            {
                return false;
            }

            return Id.Equals(bookEntity.Id) &&
                    Title == bookEntity.Title &&
                    Pages == bookEntity.Pages &&
                    ReleaseDate == bookEntity.ReleaseDate;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BookEntity))
            {
                return false;
            }

            return Equals((BookEntity)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Pages, ReleaseDate);
        }
    }
}


