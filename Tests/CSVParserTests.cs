using LoanDecider;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class CSVParserTests
    {
        CSVParser subject;

        [SetUp]
        public void SetUp()
        {
            subject = new CSVParser();
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
            var p = AppDomain.CurrentDomain.BaseDirectory + @"..\..\Resources\";
           
            Assert.Throws<FileNotFoundException>(() => subject.Parse(new FileInfo(p + @"FileThatDoesNotExists.csv")));

            Assert.Throws<InvalidDataException>(() => subject.Parse(new FileInfo(p + @"Not-A-CSV-Format-File.txt")));

            var exception = Assert.Throws<FormatException>(() => subject.Parse(new FileInfo(p + @"test-invalid-cast-data.csv")));

            Assert.AreEqual("Invalid row, unable to parse: Bob, 0.0f75, 640", exception.Message);

            var nullException = Assert.Throws<FormatException>(() => subject.Parse(new FileInfo(p + @"test-null-fields-data.csv")));

            Assert.AreEqual("Invalid row, unable to parse: , , ", nullException.Message);
        }


    }
}
