using System;
using System.Globalization;
using System.IO;
using System.Text;
using Books.Models;
using CsvHelper;

namespace Books.Classes
{
    public class FileReader
    {
        public static BookModel[] Read(string filePath)
        {
            PathValidator.ValidationForFile(filePath);

            using (var reader = new StreamReader(filePath))
            {
                int fileLength = File.ReadAllLines(filePath).Length;

                if(fileLength == 1 || fileLength == 0)
                {
                    return null;
                }

                BookModel[] bookModels = new BookModel[fileLength - 1];
                int i = 0;

                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    reader.BaseStream.Position = 0;

                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        bookModels[i] = new BookModel();

                        bookModels[i].Title = csv.GetField("Title");
                        bookModels[i].Pages = int.Parse(csv.GetField("Pages"));
                        bookModels[i].Genre = csv.GetField("Genre");

                        if (!DateTime.TryParse(csv.GetField("ReleaseDate"), out DateTime time))
                        {
                            time = DateTime.MaxValue;
                        }

                        time = TimeZoneInfo.ConvertTimeToUtc(time, TimeZoneInfo.FindSystemTimeZoneById("UTC"));
                        bookModels[i].ReleaseDate = time;

                        bookModels[i].Author = csv.GetField("Author");
                        bookModels[i].Publisher = csv.GetField("Publisher");

                        i++;
                    }
                }

                return bookModels;
            }
        }
    }
}
