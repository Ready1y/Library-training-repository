using Books.Models;
using CsvHelper.Configuration;

namespace Books.Classes
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
