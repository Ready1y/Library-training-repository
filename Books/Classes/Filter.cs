using System;

namespace Books.Classes
{
    public class Filter
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int? MoreThanPages { get; set; }
        public int? LessThanPages { get; set; }
        public DateTime? PublishedBefore { get; set; }
        public DateTime? PublishedAfter { get; set; }

        public Filter()
        {
        }

        public Filter(string title, string genre, string author, string publisher, string moreThanPages, string lessThanPages, string publishedBefore, string publishedAfter)
        {
            Title = title;
            Genre = genre;
            Author = author;
            Publisher = publisher;

            int.TryParse(moreThanPages, out int moreThanPagesInteger);
            MoreThanPages = moreThanPagesInteger;

            int.TryParse(lessThanPages, out int lessThanPagesInteger);
            LessThanPages = lessThanPagesInteger;

            DateTime.TryParse(publishedBefore, out DateTime publishedBeforeDateTime);
            PublishedBefore = publishedBeforeDateTime;

            DateTime.TryParse(publishedAfter, out DateTime publishedAfterDateTime);
            PublishedAfter = publishedAfterDateTime;
        }
    }
}