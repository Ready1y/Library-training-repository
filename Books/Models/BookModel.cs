using System;

namespace Books.Models
{
    public class BookModel
    {
        private string _title;
        private int _pages;
        private string _genre;
        private DateTime _releaseDate;
        private string _author;
        private string _publisher;

        public string Title
        {
            get => _title;
            set => _title = value;
        }
        public int Pages
        {
            get => _pages;
            set => _pages = value;
        }
        public string Genre
        {
            get => _genre; set => _genre = value;
        }
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value.ToUniversalTime();
                _releaseDate = TimeZoneInfo.ConvertTimeToUtc(_releaseDate, TimeZoneInfo.FindSystemTimeZoneById("UTC"));
            }
        }
        public string Author
        {
            get => _author; set => _author = value;
        }
        public string Publisher
        {
            get => _publisher; set => _publisher = value;
        }

        public BookModel()
        {
        }

        public BookModel(string title, int pages, string genre, string author, string publisher, DateTime releaseDate)
        {
            _title = title;
            _pages = pages;
            _genre = genre;
            _releaseDate = releaseDate;
            _author = author;
            _publisher = publisher;
        }
    }
}
