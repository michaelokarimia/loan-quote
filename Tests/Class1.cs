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


        [Test]
        public void LoadsValidCSVFile()
        {
            subject = new CSVParser();

            FileInfo validFilePath = new FileInfo(@"\\..\\..\\test-market-data.csv");
            var result = subject.Parse(validFilePath);


            Assert.That(result.Count, Is.GreaterThan(0));

        }


    }
}
