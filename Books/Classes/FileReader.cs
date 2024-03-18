using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Books.Mappers;
using Books.Models;
using CsvHelper;

namespace Books.Classes
{
    public class FileReader
    {
        private Filter _filter;

        public FileReader(Filter filter)
        {
            if(filter == null)
            {
                throw new ArgumentNullException(nameof(filter), "Filter is null");
            }

            _filter = filter;
        }

        public IReadOnlyList<BookModel> Read(string filePath)
        {
            PathValidator.ValidationForFile(filePath);

            IReadOnlyList<BookModel> bookModels;

            using (StreamReader streamReader = new(filePath))
            {
                using (CsvReader csvReader = new(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<BookCsvMapper>();

                    bookModels = csvReader.GetRecords<BookModel>()
                        .Where(book =>
                            (string.IsNullOrEmpty(_filter.Title) || book.Title == _filter.Title)
                            && (string.IsNullOrEmpty(_filter.Genre) || book.Genre == _filter.Genre)
                            && (string.IsNullOrEmpty(_filter.Author) || book.Author == _filter.Author)
                            && (string.IsNullOrEmpty(_filter.Publisher) || book.Publisher == _filter.Publisher)
                            && (_filter.MoreThanPages == null || book.Pages > _filter.MoreThanPages)
                            && (_filter.LessThanPages == null || book.Pages < _filter.LessThanPages)
                            && (_filter.PublishedBefore == null || _filter.PublishedBefore == DateTime.MinValue || DateTime.Compare(_filter.PublishedBefore.Value.ToUniversalTime(), book.ReleaseDate) > 0)
                            && (_filter.PublishedAfter == null || _filter.PublishedAfter == DateTime.MinValue || DateTime.Compare(_filter.PublishedAfter.Value.ToUniversalTime(), book.ReleaseDate) < 0)
                            )
                            .ToArray()
                        ;
                }
            }
            return bookModels; 
        }
    }
}
