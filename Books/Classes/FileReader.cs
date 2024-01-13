using System;
using System.IO;
using System.Text;

namespace Books.Classes
{
    public class FileReader
    {
        public static ModelOfBook[] Read(string filePath)
        {
            PathValidator.ValidationForFile(filePath);

            string[] lines = null;

            try
            {
                lines = File.ReadAllLines(filePath);

                if (lines.Length == 0 || lines.Length == 1)
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

                return null;
            }

            ModelOfBook[] collectionOfModels = new ModelOfBook[lines.Length - 1];

            string[] orderOfTypes = new string[]
            {
                "Title",
                "Pages",
                "Genre",
                "ReleaseDate",
                "Author",
                "Publisher"
            };
            StringBuilder infoAboutType = new StringBuilder();

            int numberOfType = 0;

            for(int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                collectionOfModels[i-1] = new ModelOfBook();

                for(int j = 0; j < line.Length; j++)
                {
                    if (line[j] == ',' && line[j + 1] != ' ')
                    {
                        collectionOfModels[i - 1].Update(orderOfTypes[numberOfType], infoAboutType.ToString());

                        numberOfType++;
                        infoAboutType.Clear();
                    }
                    else if(j == line.Length - 1)
                    {
                        infoAboutType.Append(line[j]);

                        collectionOfModels[i - 1].Update(orderOfTypes[numberOfType], infoAboutType.ToString());

                        numberOfType = 0;
                        infoAboutType.Clear();
                    }
                    else
                    {
                        infoAboutType.Append(line[j]);
                    }
                }
            }

            return collectionOfModels;
        }
    }
}
