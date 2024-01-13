using System;

namespace Books.Classes
{
    public class ModelOfBook
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
        }
        public int Pages 
        {
            get => _pages;
        }
        public string Genre
        {
            get => _genre;
        }
        public DateTime ReleaseDate 
        {
            get => _releaseDate; 
        }
        public string Author 
        { 
            get => _author; 
        }
        public string Publisher 
        { 
            get => _publisher;
        }

        public ModelOfBook()
        {
        }

        public ModelOfBook(string title, int pages, string genre,  string author, string publisher, DateTime releaseDate)
        {
            _title = title;
            _pages = pages;
            _genre = genre;
            _releaseDate = releaseDate;
            _author = author;
            _publisher = publisher;
        }

        public void Update(string parameterName, string value)
        {
            if(parameterName == null)
            {
                throw new ArgumentNullException(nameof(parameterName), "Parameter name is null");
            }

            if(parameterName == string.Empty)
            {
                throw new ArgumentException("Parameter name is empty string", nameof(parameterName));
            }

            switch (parameterName)
            {
                case nameof(Title):
                    _title = value; 

                    break;

                case nameof(Pages):
                    if (!int.TryParse(value, out _pages))
                    {
                        _pages = 0;
                    }

                    break;

                case nameof(Genre): 
                    _genre = value; 

                    break;

                case nameof(ReleaseDate):
                    if(!DateTime.TryParse(value, out DateTime time))
                    {
                        time = DateTime.MaxValue;
                    }
                    
                    time = TimeZoneInfo.ConvertTimeToUtc(time, TimeZoneInfo.FindSystemTimeZoneById("UTC"));

                    _releaseDate = time;

                    break;

                case nameof(Author):
                    _author = value;

                    break;

                case nameof(Publisher):
                    _publisher = value;

                    break;
            }
        }
    }
}
