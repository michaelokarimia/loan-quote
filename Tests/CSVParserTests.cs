using LoanDecider;
using NUnit.Framework;
using System;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class CSVParserTests
    {
        CSVParser subject;
        string basePath;

        [SetUp]
        public void SetUp()
        {
            subject = new CSVParser();
            basePath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\Resources\";
        }

        [Test]
        public void LoadsValidCSVFile()
        {

            string path = AppDomain.CurrentDomain.BaseDirectory + @"..\..\Resources\test-market-data.csv";

            FileInfo validFilePath = new FileInfo(path);

            var result = subject.Parse(validFilePath);

            Assert.That(result.Count, Is.EqualTo(7));

        }

        [Test]
        public void ThrowsExceptionWhenGivenInvalidInputData()
        {
            
           
            Assert.Throws<FileNotFoundException>(() => subject.Parse(new FileInfo(basePath + @"FileThatDoesNotExists.csv")));

            Assert.Throws<InvalidDataException>(() => subject.Parse(new FileInfo(basePath + @"Not-A-CSV-Format-File.txt")));

            var exception = Assert.Throws<FormatException>(() => subject.Parse(new FileInfo(basePath + @"test-invalid-cast-data.csv")));

            Assert.AreEqual("Invalid row, unable to parse: Bob, 0.0f75, 640", exception.Message);

            var nullException = Assert.Throws<FormatException>(() => subject.Parse(new FileInfo(basePath + @"test-null-fields-data.csv")));

            Assert.AreEqual("Invalid row, unable to parse: , , ", nullException.Message);

        }

        [Test]
        public void CanParseCSVWithBlankLines()
        {
            var listOfLenders = subject.Parse(new FileInfo(basePath + @"test-null-rows-data.csv"));

            Assert.AreEqual(2, listOfLenders.Count);

        }

    }
}
