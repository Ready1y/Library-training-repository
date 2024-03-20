using System;
using System.Collections.Generic;

namespace Books.Entities
{
    public class BookEntity : IEquatable<object>, IEquatable<BookEntity>
    {
        private DateTime _releaseDate;

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }

        public DateTime ReleaseDate 
        {
            get => _releaseDate;

            set
            {
                _releaseDate = TimeZoneInfo.ConvertTimeToUtc(value, TimeZoneInfo.FindSystemTimeZoneById("UTC"));
            }
        }

        public ICollection<AuthorEntity> Authors { get; set; }
        public ICollection<PublisherEntity> Publishers { get; set; }
        public ICollection<GenreEntity> Genres { get; set; }

        public bool Equals(BookEntity bookEntity)
        {
            if (bookEntity == null)
            {
                return false;
            }

            return Id.Equals(bookEntity.Id) 
                && Title == bookEntity.Title 
                && Pages == bookEntity.Pages 
                && ReleaseDate == bookEntity.ReleaseDate
            ;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BookEntity);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Pages, ReleaseDate);
        }
    }
}


