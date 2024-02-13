using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Books.Models;
using CsvHelper;

namespace Books.Classes
{
    public class FileReader
    {
        public static BookModel[] Read(string filePath)
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

            return bookModels.ToArray();
        }
    }
}
