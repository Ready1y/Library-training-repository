using System;

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
                _releaseDate = value.ToUniversalTime();
                _releaseDate = TimeZoneInfo.ConvertTimeToUtc(_releaseDate, TimeZoneInfo.FindSystemTimeZoneById("UTC"));
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
    }
}
