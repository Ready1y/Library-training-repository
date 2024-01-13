using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Books.Classes
{
    public class Filter
    {
        private readonly IConfiguration _configuration;

        public Filter()
        {
        }

        public Filter(IConfiguration configuration)
        {
            if(configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), "Configuration is null");
            }

            _configuration = configuration;

            Title = _configuration["FilterSettings:Title"];
            Genre = _configuration["FilterSettings:Genre"];
            Author = _configuration["FilterSettings:Author"];
            Publisher = _configuration["FilterSettings:Publisher"];

            int.TryParse(_configuration["FilterSettings:MoreThanPages"], out int moreThanPages);
            MoreThanPages = moreThanPages;

            int.TryParse(_configuration["FilterSettings:LessThanPages"], out int lessThanPages);
            LessThanPages = lessThanPages;

            DateTime.TryParse(_configuration["FilterSettings:PublishedBefore"], out DateTime publishedBefore);
            PublishedBefore = publishedBefore;

            DateTime.TryParse(_configuration["FilterSettings:PublishedAfter"], out DateTime publishedAfter);
            PublishedAfter = publishedAfter;
        }

        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public int? MoreThanPages { get; set; }
        public int? LessThanPages { get; set; }
        public DateTime? PublishedBefore { get; set; }
        public DateTime? PublishedAfter { get; set; }

        public Dictionary<uint, ModelOfBook> FindBooksInContext(Context context)
        {
            if(context == null)
            {
                throw new ArgumentNullException(nameof(context), "Context is null");
            }

            Dictionary<uint, ModelOfBook> dictionaryOfBooks = new Dictionary<uint, ModelOfBook>();
            uint numberOfBookInDictionary = 1;

            Dictionary<string, Genre> genresInContext = new Dictionary<string, Genre>();
            foreach(var genre in context.Genres.Local)
            {
                genresInContext[genre.Id.ToString()] = genre;
            }

            Dictionary<string, Author> authorsInContext = new Dictionary<string, Author>();
            foreach (var author in context.Authors.Local)
            {
                authorsInContext[author.Id.ToString()] = author;
            }

            Dictionary<string, Publisher> publishersInContext = new Dictionary<string, Publisher>();
            foreach (var publisher in context.Publishers.Local)
            {
                publishersInContext[publisher.Id.ToString()] = publisher;
            }

            foreach (var book in context.Books.Local)
            {
                string genreName = genresInContext[book.GenreId.ToString()].Name;
                string authorName = authorsInContext[book.AuthorId.ToString()].Name;
                string publisherName = publishersInContext[book.PublisherId.ToString()].Name;

                if (Title != null && Title != string.Empty && book.Title != Title)
                {
                    continue;
                }

                if (Genre != null && Genre != string.Empty && genreName != Genre)
                {
                        continue;
                }

                if (Author != null && Author != string.Empty && authorName != Author)
                {
                        continue;
                }

                if (Publisher != null && Publisher != string.Empty && publisherName != Publisher)
                {
                        continue;
                }

                if (MoreThanPages != null && MoreThanPages != 0 && book.Pages <= MoreThanPages)
                {
                    continue;
                }

                if (LessThanPages != null && LessThanPages != 0 && book.Pages >= LessThanPages)
                {
                    continue;
                }

                if (PublishedBefore != null && PublishedBefore != DateTime.MinValue && DateTime.Compare((DateTime)PublishedBefore, book.ReleaseDate) <= 0)
                {
                        continue;
                }

                if (PublishedAfter != null && PublishedAfter != DateTime.MinValue && DateTime.Compare((DateTime)PublishedAfter, book.ReleaseDate) >= 0)
                {
                        continue;
                }

                ModelOfBook modelOfBook = new ModelOfBook(book.Title, book.Pages, genreName, authorName, publisherName, book.ReleaseDate);

                dictionaryOfBooks.Add(numberOfBookInDictionary++, modelOfBook);
            }

            return dictionaryOfBooks;
        }
    }
}