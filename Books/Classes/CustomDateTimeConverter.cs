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
            if(memberMapData == null)
            {   
                throw new ArgumentNullException(nameof(memberMapData), "Member map data is null");
            }

            if(row == null)
            {
                throw new ArgumentNullException(nameof(row), "Row is null");
            }

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
