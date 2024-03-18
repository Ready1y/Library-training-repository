using Books.Classes;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Reflection;
using System.Globalization;
using CsvHelper.TypeConversion;

namespace Books.Tests.UnitTesting.MSTests
{
    [TestClass]
    public class CustomDateTimeConverterTests
    {
        [TestMethod]
        public void ConvertFromString_WhenInputIsCorrect_ReturnsDefaultDateTime()
        {
            const string date = "10-10-1000";

            DateTime expectedDateTime = new DateTime(1000, 10, 10);

            CustomDateTimeConverter converter = new CustomDateTimeConverter();

            TypeConverterOptions options = new TypeConverterOptions()
            {
                CultureInfo = CultureInfo.InvariantCulture
            };

            Type attributesType = null;

            Mock<CsvConfiguration> csvConfigurationMock = new Mock<CsvConfiguration>(options.CultureInfo, attributesType);
            Mock<CsvContext> csvContextMock = new Mock<CsvContext>(csvConfigurationMock.Object);
            Mock<IReaderConfiguration> readerConfigurationMock = new Mock<IReaderConfiguration>();
            Mock<IReaderRow> readerRowMock = new Mock<IReaderRow>();

            readerRowMock
                .Setup(x => x.Configuration)
                .Returns(readerConfigurationMock.Object);

            readerRowMock
                .Setup(x => x.Context)
                .Returns(csvContextMock.Object);

            Mock<MemberInfo> memberInfoMock = new Mock<MemberInfo>();
            Mock<MemberMapData> memberMapDataMock = new Mock<MemberMapData>(memberInfoMock.Object);

            memberMapDataMock
                .Setup(x => x.Default)
                .Returns(DateTime.MinValue);
            memberMapDataMock
                .Setup(x => x.Type)
                .Returns(typeof(DateTime));
            memberMapDataMock
                .Setup(x => x.TypeConverterOptions)
                .Returns(options);

            var result = converter.ConvertFromString(date, readerRowMock.Object, memberMapDataMock.Object);

            Assert.AreEqual(expectedDateTime, result);
        }

        [TestMethod]
        public void ConvertFromString_WhenInputIsInvalid_ReturnsDefaultDateTime()
        {
            const string date = "invalid date";
            CustomDateTimeConverter converter = new CustomDateTimeConverter();

            TypeConverterOptions options = new TypeConverterOptions()
            {
                CultureInfo = CultureInfo.InvariantCulture
            };

            Type attributesType = null;

            Mock<CsvConfiguration> csvConfigurationMock = new Mock<CsvConfiguration>(options.CultureInfo, attributesType);
            Mock<CsvContext> csvContextMock = new Mock<CsvContext>(csvConfigurationMock.Object);
            Mock<IReaderConfiguration> readerConfigurationMock = new Mock<IReaderConfiguration>();
            Mock<IReaderRow> readerRowMock = new Mock<IReaderRow>();

            readerRowMock
                .Setup(x => x.Configuration)
                .Returns(readerConfigurationMock.Object);

            readerRowMock
                .Setup(x => x.Context)
                .Returns(csvContextMock.Object);

            Mock<MemberInfo> memberInfoMock = new Mock<MemberInfo>();
            Mock<MemberMapData> memberMapDataMock = new Mock<MemberMapData>(memberInfoMock.Object);

            memberMapDataMock
                .Setup(x => x.Default)
                .Returns(DateTime.MinValue); 
            memberMapDataMock
                .Setup(x => x.Type)
                .Returns(typeof(DateTime));
            memberMapDataMock
                .Setup(x => x.TypeConverterOptions)
                .Returns(options);

            var result = converter.ConvertFromString(date, readerRowMock.Object, memberMapDataMock.Object);

            Assert.AreEqual(default(DateTime), result);
        }

        [TestMethod]
        public void Test_ConvertFromString_WhenMemberMapDataIsNull_ThrowsArgumentNullException()
        {
            const string date = "10-10-1900";
            IReaderRow row = new Mock<IReaderRow>().Object;
            MemberMapData memberMapData = null;

            CustomDateTimeConverter converter = new CustomDateTimeConverter();

            Action action = () => converter.ConvertFromString(date, row, memberMapData);

            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void Test_ConvertFromString_WhenRowIsNull_ThrowsArgumentNullException()
        {
            const string date = "10-10-1900";
            IReaderRow row = null;
            MemberMapData memberMapData = new MemberMapData(null);

            CustomDateTimeConverter converter = new CustomDateTimeConverter();

            Action action = () => converter.ConvertFromString(date, row, memberMapData);

            Assert.ThrowsException<ArgumentNullException>(action);
        }
    }
}
