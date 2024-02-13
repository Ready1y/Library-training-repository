using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using CsvHelper;
using System;

namespace Books.Classes
{
    public class CustomDateTimeConverter : DateTimeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            try
            {
                return base.ConvertFromString(text, row, memberMapData);
            }
            catch (TypeConverterException)
            {
                return default(DateTime);
            }
        }
    }
}
