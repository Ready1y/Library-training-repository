using System;
using System.Globalization;

namespace Books.Models
{
    public class BookModel
    {
        private DateTime _releaseDate;

        public string Title { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = TimeZoneInfo.ConvertTimeToUtc(value, TimeZoneInfo.FindSystemTimeZoneById("UTC"));
            }
        }


        public BookModel()
        {
        }

        public BookModel(string title, int pages, string genre, string author, string publisher, DateTime releaseDate)
        {
            if(title == null)
            {
                throw new ArgumentNullException(nameof(title), "Title is null");
            }

            if(genre == null)
            {
                throw new ArgumentNullException(nameof(genre), "Genre is null");
            }

            if(author == null)
            {
                throw new ArgumentNullException(nameof(author), "Author is null");
            }

            if(publisher == null)
            {
                throw new ArgumentNullException(nameof(publisher), "Publisher is null");
            }

            Title = title;
            Pages = pages;
            Genre = genre;
            ReleaseDate = releaseDate;
            Author = author;
            Publisher = publisher;
        }

        public override bool Equals(object obj)
        {
            return obj is BookModel model &&
                   _releaseDate == model._releaseDate &&
                   Title == model.Title &&
                   Pages == model.Pages &&
                   Genre == model.Genre &&
                   Author == model.Author &&
                   Publisher == model.Publisher &&
                   ReleaseDate == model.ReleaseDate;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_releaseDate, Title, Pages, Genre, Author, Publisher, ReleaseDate);
        }
    }
}
