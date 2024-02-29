using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Books.Entities;
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

                    bookModels = csvReader.GetRecords<BookModel>().ToArray();
                }
            }
            return bookModels
                .Where(book =>
                    (_filter.Title == null || _filter.Title == string.Empty || book.Title == _filter.Title)
                    && (_filter.Genre == null || _filter.Genre == string.Empty || book.Genre == _filter.Genre)
                    && (_filter.Author == null || _filter.Author == string.Empty || book.Author == _filter.Author)
                    && (_filter.Publisher == null || _filter.Publisher == string.Empty || book.Publisher == _filter.Publisher)
                    && (_filter.MoreThanPages == null || book.Pages > _filter.MoreThanPages)
                    && (_filter.LessThanPages == null || book.Pages < _filter.LessThanPages)
                    && (_filter.PublishedBefore == null || _filter.PublishedBefore == DateTime.MinValue || DateTime.Compare(_filter.PublishedBefore.Value.ToUniversalTime(), book.ReleaseDate) > 0)
                    && (_filter.PublishedAfter == null || _filter.PublishedAfter == DateTime.MinValue || DateTime.Compare(_filter.PublishedAfter.Value.ToUniversalTime(), book.ReleaseDate) < 0)
                    )
                    .ToArray()
                ; 
        }
    }
}
