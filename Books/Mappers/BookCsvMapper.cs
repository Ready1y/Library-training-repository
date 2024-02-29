using System;
using Books.Classes;
using Books.Models;
using CsvHelper.Configuration;

namespace Books.Mappers
{
    public class BookCsvMapper : ClassMap<BookModel>
    {
        public BookCsvMapper()
        {
            Map(x => x.Title);
            Map(x => x.Pages);
            Map(x => x.ReleaseDate).TypeConverter<CustomDateTimeConverter>();
            Map(x => x.Author);
            Map(x => x.Genre);
            Map(x => x.Publisher);
        }
    }
}
